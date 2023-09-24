using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deguard_Tool.Main_Menu_Buttons
{
    public partial class winprefetch : UserControl
    {
        private Dictionary<string, string> fileBackup = new Dictionary<string, string>();
        private ListBox lstFiles = new ListBox();
        public winprefetch()
        {
            InitializeComponent();
            InitializeListBox();
        }

        private void InitializeListBox()
        {
            lstFiles.Location = new Point(16, 95);
            lstFiles.ForeColor = Color.FromArgb(5, 5, 5);
            lstFiles.BackColor = Color.FromArgb(5, 5, 5);
            lstFiles.BorderStyle = BorderStyle.None;
            lstFiles.ForeColor = Color.White;
            lstFiles.Font = new Font("Verdana", 9.75f, FontStyle.Bold);
            lstFiles.Size = new Size(40, 40);
            this.Controls.Add(lstFiles);
        }

        private void winprefetch_Load(object sender, EventArgs e)
        {
            string searchDirectory = @"C:\Windows\Prefetch";
            string searchPattern = "searchfilterhost*.*";

            List<string> files = FindFiles(searchDirectory, searchPattern);
            lstFiles.Items.AddRange(files.ToArray());
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem != null)
            {
                string selectedFile = lstFiles.SelectedItem.ToString();

                if (!fileBackup.ContainsKey(selectedFile))
                {
                    string content = File.ReadAllText(selectedFile);
                    fileBackup[selectedFile] = content;
                }

                File.WriteAllText(selectedFile, "dsakhjkjhk1");

                MessageBox.Show($"Bypass Successfully Completed", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select the file.", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem != null && fileBackup.ContainsKey(lstFiles.SelectedItem.ToString()))
            {
                string selectedFile = lstFiles.SelectedItem.ToString();
                string content = fileBackup[selectedFile];

                File.WriteAllText(selectedFile, content);


                MessageBox.Show($"Completed Successfully", "Undo Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a file.", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<string> FindFiles(string directory, string searchPattern)
        {
            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(directory, searchPattern, SearchOption.TopDirectoryOnly));

            string[] subdirectories = Directory.GetDirectories(directory);
            foreach (string subdirectory in subdirectories)
            {
                files.AddRange(FindFiles(subdirectory, searchPattern));
            }

            return files;
        }
    }
}