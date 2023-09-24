using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.IO;
using Siticone.UI.WinForms;
using Deguard_Tool.Anti_SS;

namespace Deguard_Tool
{

    public partial class antiss : UserControl
    {
        public antiss()
        {
            InitializeComponent();
        }

        private void antiss_Load(object sender, EventArgs e)
        {

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton4_Click_1(object sender, EventArgs e)
        {
            everything1.Location = new System.Drawing.Point(43, 70);
            everything1.BringToFront();
            everything1.Visible = true;
        }

        private void siticoneButton5_Click_1(object sender, EventArgs e)
        {
            shadowexplorer1.Location = new System.Drawing.Point(43, 70);
            shadowexplorer1.BringToFront();
            shadowexplorer1.Visible = true;
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            automaticcleanreg1.Visible = false;
            automaticcleanreg1.SendToBack();
            siticoneLabel1.Visible = false;
            cleartraces1.Visible = true;
            cleartraces1.BringToFront();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            autoclean1.Visible = false;
            autoclean1.SendToBack();
            cleartraces1.Visible = false;
            cleartraces1.SendToBack();
            automaticcleanreg1.Visible = false;
            automaticcleanreg1.SendToBack();
            siticoneLabel1.Visible = true;
            cleartraces1.Visible = false;
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            winprefetch1.Visible = true;
            winprefetch1.BringToFront();
            winprefetch1.Location = new System.Drawing.Point(54, 79);
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            automaticcleanreg1.Visible = true;
            automaticcleanreg1.BringToFront();
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Danny Will Be Adding This Soon!", "Deguard");
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            autoclean1.Visible = true;
            autoclean1.BringToFront();
        }
    }
}