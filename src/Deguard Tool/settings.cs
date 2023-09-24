using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deguard_Tool
{
    public partial class settings : UserControl
    {
        public event EventHandler<ImageChangedEventArgs> ImageChanged;
        public settings()
        {
            InitializeComponent();
        }

        private void traybutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;
                    Image image = Image.FromFile(imagePath);

                    ImageChanged?.Invoke(this, new ImageChangedEventArgs(image));
                }
            }
        }
    }

    public class ImageChangedEventArgs : EventArgs
    {
        public Image NewImage { get; }

        public ImageChangedEventArgs(Image newImage)
        {
            NewImage = newImage;
        }
    }
}