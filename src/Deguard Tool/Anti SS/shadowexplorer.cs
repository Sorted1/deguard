using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace Deguard_Tool
{
    public partial class shadowexplorer : UserControl
    {
        public shadowexplorer()
        {
            InitializeComponent();
            PopulateDriveComboBox();
        }

        private void PopulateDriveComboBox()
        {
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                drivecomboBox.Items.Add($"{drive} Drive");
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (drivecomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a drive before deleting shadow copies.", "Drive Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsUserAdministrator())
            {
                MessageBox.Show("The application needs to be run with administrative privileges to delete shadow copies.", "Administrator Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedDrive = drivecomboBox.SelectedItem.ToString();
            string driveLetter = selectedDrive.Substring(0, 2);

            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C vssadmin delete shadows /all /quiet /For={driveLetter}",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                Process.Start(processInfo);

                MessageBox.Show($"Shadow copies for {driveLetter} drive have been deleted.", "Shadow Copy Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is IOException || ex is InvalidOperationException || ex is Win32Exception)
            {
                MessageBox.Show($"An error occurred while deleting shadow copies:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsUserAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            this.Visible = false;
        }
    }
}
