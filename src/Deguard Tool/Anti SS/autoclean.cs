using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deguard_Tool.Anti_SS
{
    public partial class autoclean : UserControl
    {
        public autoclean()
        {
            InitializeComponent();
        }

        private void deepcleanbtn_Click(object sender, EventArgs e)
        {
            {
                RestartExplorer();
                ClearTempFolder();
                ClearChromeHistory();
                ClearOperaHistory();
                ClearUserTempFolder();
                DeleteShadowCopies();
                ClearShellRecentFolder();
                DeleteNvidiaControlPanelFile();
                ClearCrashDumpsFolder();
                DeleteUSNJournal();
                ClearLoaderPrefetchFiles();
                ClearVirusHistory();
                MessageBox.Show("Operation Completed.", "Success");
            }
        }

        private void ClearTempFolder()
        {
            try
            {
                string tempFolderPath = @"C:\Windows\Temp";
                DirectoryInfo tempDirectory = new DirectoryInfo(tempFolderPath);

                foreach (FileInfo file in tempDirectory.GetFiles())
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting temporary files: {ex.Message}", "Error");
            }
        }

        private void RestartExplorer()
        {
            try
            {
                RestartExplorer1();
                Console.WriteLine("Windows Explorer restarted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while restarting Windows Explorer:");
                Console.WriteLine(ex.Message);
            }
        }

        static void RestartExplorer1()
        {
            Process[] explorerProcesses = Process.GetProcessesByName("explorer");
            foreach (Process explorerProcess in explorerProcesses)
            {
                explorerProcess.Kill();
                explorerProcess.WaitForExit();
            }

            Process.Start("explorer.exe");
        }

        private void ClearChromeHistory()
        {
            try
            {
                string filePath = @"C:\Users\fryda\AppData\Local\Google\Chrome\User Data\Default\History";
                DeleteFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the Chrome history: {ex.Message}", "Error");
            }
        }

        private void ClearOperaHistory()
        {
            try
            {
                string filePath = @"C:\Users\fryda\AppData\Roaming\Opera Software\Opera GX Stable\History";
                DeleteFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the Opera history: {ex.Message}", "Error");
            }
        }

        private void ClearUserTempFolder()
        {
            try
            {
                string tempFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp");
                DirectoryInfo tempDirectory = new DirectoryInfo(tempFolderPath);

                foreach (FileInfo file in tempDirectory.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo directory in tempDirectory.GetDirectories())
                {
                    directory.Delete(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting temp files and folders: {ex.Message}", "Error");
            }
        }

        private void DeleteShadowCopies()
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = new Process
                {
                    StartInfo = processInfo
                };

                process.Start();

                process.StandardInput.WriteLine("vssadmin delete shadows /all /quiet");
                process.StandardInput.WriteLine("exit");

                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the shadow copies: {ex.Message}", "Error");
            }
        }

        private void ClearShellRecentFolder()
        {
            try
            {
                string recentFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\Recent");
                DirectoryInfo recentFolder = new DirectoryInfo(recentFolderPath);

                foreach (FileInfo file in recentFolder.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo directory in recentFolder.GetDirectories())
                {
                    directory.Delete(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting recent files: {ex.Message}", "Error");
            }
        }

        private void DeleteNvidiaControlPanelFile()
        {
            try
            {
                string filePath = @"C:\ProgramData\NVIDIA Corporation\Drs\nvAppTimestamps";
                DeleteFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the NVIDIA Control Panel file: {ex.Message}", "Error");
            }
        }

        private void ClearCrashDumpsFolder()
        {
            try
            {
                string crashDumpsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CrashDumps");
                ClearDirectory(crashDumpsFolderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while clearing the Crash Dumps folder: {ex.Message}", "Error");
            }
        }


        private void DeleteUSNJournal()
        {
            try
            {
                Process.Start("fsutil", "usn deletejournal /d C:");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the USN Journal: {ex.Message}", "Error");
            }
        }

        private void ClearLoaderPrefetchFiles()
        {
            try
            {
                string prefetchDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Prefetch");
                ClearFilesStartingWith(prefetchDirectory, "loader");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while clearing the Loader prefetch files: {ex.Message}", "Error");
            }
        }

        private void ClearVirusHistory()
        {
            try
            {
                string virusHistoryFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Microsoft\Windows Defender\Scans\History\Service\DetectionHistory");
                ClearDirectory(virusHistoryFolderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while clearing the Virus history: {ex.Message}", "Error");
            }
        }

        private void ClearDirectory(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while clearing the directory: {ex.Message}", "Error");
            }
        }

        private void DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the file: {ex.Message}", "Error");
            }
        }

        private void ClearFilesStartingWith(string directoryPath, string fileNamePrefix)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    foreach (string file in Directory.GetFiles(directoryPath))
                    {
                        if (Path.GetFileName(file).StartsWith(fileNamePrefix))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while clearing the files: {ex.Message}", "Error");
            }
        }
    }
}