using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace Deguard_Tool
{
    public partial class destruct : UserControl
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private bool isMinimizedToTray;

        public destruct()
        {
            InitializeComponent();
            InitializeTrayComponents();
        }

        private void InitializeTrayComponents()
        {
            traybutton.Click += traybutton_Click;
            this.Controls.Add(traybutton);
            trayIcon = new NotifyIcon();
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Show Application", OnShowApplication);
            trayMenu.MenuItems.Add("Exit", OnExit);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Icon = Icon.FromHandle(Properties.Resources.Dannyisdaddy.GetHicon());
            trayIcon.Click += OnShowApplication;
        }

        private void OnShowApplication(object sender, EventArgs e)
        {
            this.ParentForm.Show();
            trayIcon.Visible = false;
            isMinimizedToTray = false;
        }

        private void OnExit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void traybutton_Click(object sender, EventArgs e)
        {
            if (!isMinimizedToTray)
            {
                this.ParentForm.Hide();
                trayIcon.Visible = true;
                isMinimizedToTray = true;
            }
            else
            {
                this.Show();
                trayIcon.Visible = false;
                isMinimizedToTray = false;
            }
        }

        private void destruct_Load(object sender, EventArgs e)
        {
            
        }
    }
}