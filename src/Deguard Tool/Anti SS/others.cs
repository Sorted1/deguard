using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Deguard_Tool.Anti_SS
{
    public partial class others : UserControl
    {
        public others()
        {
            InitializeComponent();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select File to Change Date";
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file's path
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Calculate the new date (3 months and 4 hours ago)
                        DateTime newDate = DateTime.Now.AddMonths(-3).AddHours(-4).AddMinutes(-5);

                        // Update the file's creation, last access, last write, and modified dates
                        File.SetCreationTime(filePath, newDate);
                        File.SetLastAccessTime(filePath, newDate);
                        File.SetLastWriteTime(filePath, newDate);
                        File.SetLastWriteTimeUtc(filePath, newDate);

                        MessageBox.Show("File date changed successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while changing the file date: " + ex.Message);
                    }
                }
            }
        }
    }
}