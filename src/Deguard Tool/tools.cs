using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Deguard_Tool
{
    public partial class tools : UserControl
    {
        public tools()
        {
            InitializeComponent();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            string fileUrl = "https://raw.githubusercontent.com/SplashGG/dl/main/strless.exe";
            string saveFilePath = Path.Combine(Path.GetTempPath(), "dtys.exe");

            try
            {
                using (var httpClient = new WebClient())
                {
                    httpClient.DownloadFile(fileUrl, saveFilePath);

                    Process.Start(saveFilePath);
                    MessageBox.Show("Stringless Executed Successfully");

                    File.Delete(saveFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}");
            }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Process taskkillProcess = new Process();
                taskkillProcess.StartInfo.FileName = "cmd.exe";
                taskkillProcess.StartInfo.Arguments = "/C taskkill /f /im anydesk.exe";
                taskkillProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                taskkillProcess.Start();
                taskkillProcess.WaitForExit();

                string username = Environment.UserName;
                string anyDeskFolderPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "AnyDesk");

                if (Directory.Exists(anyDeskFolderPath))
                {
                    Directory.Delete(anyDeskFolderPath, true);
                    MessageBox.Show("Successfully Changed.");
                }
                else
                {
                    MessageBox.Show("AnyDesk Is Not On Computer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}