using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deguard_Tool
{
    public partial class regclean : UserControl
    {
        public regclean()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] registryPaths = {
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store",
                    @"HKEY_CURRENT_USER\Software\WinRAR\ArcHistory",
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\OpenSavePidlMRU\dll",
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\OpenSavePidlMRU\exe",
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\OpenSavePidlMRU\exe",
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\RecentDocs",
                    @"HKEY_CLASSES_ROOT\Local Settings\Software\Microsoft\Windows\Shell\MuiCache",
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\WordWheelQuery",
                    @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\bam\State\UserSettings",
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store",
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\OpenSavePidlMRU",
                    @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\LastVisitedPidlMRU",
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ComDlg32\CIDSizeMRU",
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Tracing",
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\RunMRU",
                    @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall",
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FeatureUsage\AppSwitched",
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet",
                    @"HKEY_CURRENT_USERSoftware\Microsoft\Windows\CurrentVersion\Explorer\TypedPaths",
                    @"Computer\HKEY_CURRENT_USER\SOFTWARE\Microsoft\DirectInput\MostRecentApplication",
                    @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\RecentDocs",
                    @"HKEY_CLASSES_ROOT\Local Settings\Software\Microsoft\Windows\Shell\MuiCache",
                    @"Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Search\VolumeInfoCache",
                    @"Computer\HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Enum\USBSTOR",
                    @"Computer\HKEY_LOCAL_MACHINE\SYSTEM\MountedDevices",
                    @"Computer\HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Enum\STORAGE\Volume"
                };

                foreach (string path in registryPaths)
                {
                    RunRegistryDeleteCommand(path);
                }

                MessageBox.Show("Registry cleanup completed.", "Registry Cleanup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while cleaning the registry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunRegistryDeleteCommand(string registryPath)
        {
            Process process = new Process();
            process.StartInfo.FileName = "reg.exe";
            process.StartInfo.Arguments = $"delete \"{registryPath}\" /f /va";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
        }
    }
}
