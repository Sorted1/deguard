using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Deguard_Tool
{
    public partial class everything : UserControl
    {
        private byte[] originalBytes;
        private string filePath;
        public everything()
        {
            InitializeComponent();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    originalBytes = File.ReadAllBytes(filePath);
                    File.WriteAllBytes(filePath, new byte[0]);
                    MessageBox.Show("Succes!", "Deguard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            if (filePath != null && originalBytes != null)
            {
                File.WriteAllBytes(filePath, originalBytes);
                originalBytes = null;
                MessageBox.Show("Undo successful!", "Undo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No file to undo changes on.", "Undo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void everything_Load(object sender, EventArgs e)
        {

        }
    }
}