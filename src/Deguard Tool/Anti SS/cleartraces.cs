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
    public partial class cleartraces : UserControl
    {
        public cleartraces()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (tempCheckBo.Checked)
            {
                ClearTempFolder();
                MessageBox.Show("Temp folder cleaned.", "Success");
            }

            if (chromeHistoryCheckBox.Checked)
            {
                clearChromeHistory();
                MessageBox.Show("Chrome history has been cleared.", "Success");
            }

            if (operaHistoryCheckBox.Checked)
            {
                ClearOperaHistory();
                MessageBox.Show("Opera history has been cleared.", "Success");
            }

            if (userTempCheckBox.Checked)
            {
                ClearUserTempFolder();
                MessageBox.Show("%Temp% folder cleaned.", "Success");
            }

            if (shadowCopiesCheckBox.Checked)
            {
                DeleteShadowCopies();
                MessageBox.Show("Shadow copies deleted.", "Success");
            }

            if (shellRecentCheckBox.Checked)
            {
                ClearShellRecentFolder();
                MessageBox.Show("Shell Recent folder cleared.", "Success");
            }

            if (nvidiaControlPanelCheckBox.Checked)
            {
                DeleteNvidiaControlPanelFile();
                MessageBox.Show("NVIDIA Control Panel file deleted.", "Success");
            }

            if (crashDumpsCheckBox.Checked)
            {
                ClearCrashDumpsFolder();
                MessageBox.Show("Crash dumps cleared.", "Success");
            }

            if (changeFileDateCheckBox.Checked)
            {
                ChangeFileDate();
                MessageBox.Show("File date changed.", "Success");
            }

            if (journalCheckBox.Checked)
            {
                JournalDeletion();
            }


            if (loaderPrefetchFilesCheckBox.Checked)
            {
                ClearLoaderPrefetchFiles();
                MessageBox.Show("Loader prefetch files cleared.", "Success");
            }

            if (virusHistoryCheckBox.Checked)
            {
                ClearVirusHistory();
                MessageBox.Show("Virus history cleared.", "Success");
            }
        }

        private void JournalDeletion()
        {
            try
            {
                Process.Start("fsutil", "usn deletejournal /d C:");
                MessageBox.Show("USN Journal history cleared.", "Success");

                var eventLogsToRemove = new Dictionary<string, int>
        {
            { "Application", 3079 },
        };

                foreach (var entry in eventLogsToRemove)
                {
                    string eventLogName = entry.Key;
                    int eventLogIdToRemove = entry.Value;

                    string script = $"Get-WinEvent -LogName '{eventLogName}' | Where-Object {{ $_.Id -eq {eventLogIdToRemove} }} | ForEach-Object {{ Remove-WinEvent -LogName '{eventLogName}' -InstanceId $_.Id }}";

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-WindowStyle Hidden -NoProfile -ExecutionPolicy Bypass -Command \"{script}\"",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    };

                    Process process = new Process { StartInfo = psi };
                    process.Start();

                    MessageBox.Show($"Cleared Journal Traces.", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
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

        private void clearChromeHistory()
        {
            try
            {
                string filePath = @"C:\Users\fryda\AppData\Local\Google\Chrome\User Data\Default\History";
                DeleteFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the history: {ex.Message}", "Error");
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
                MessageBox.Show($"An error occurred while deleting the history: {ex.Message}", "Error");
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
                Process.Start("cmd.exe", "/C vssadmin delete shadows /all /quiet");
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

        private void ChangeFileDate()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string powerShellCommand = $@"powershell -Command ""(Get-Item '{filePath}').LastWriteTime = '02/14/2023 15:42:16'""";

                    Process.Start("cmd.exe", $"/C {powerShellCommand}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while changing the file date: {ex.Message}", "Error");
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

        private void journalCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
