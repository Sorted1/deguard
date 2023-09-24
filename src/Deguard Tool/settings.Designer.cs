namespace Deguard_Tool
{
    partial class settings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.traybutton = new Siticone.UI.WinForms.SiticoneButton();
            this.siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
            this.SuspendLayout();
            // 
            // traybutton
            // 
            this.traybutton.BorderRadius = 5;
            this.traybutton.CheckedState.Parent = this.traybutton;
            this.traybutton.CustomImages.Parent = this.traybutton;
            this.traybutton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.traybutton.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.traybutton.ForeColor = System.Drawing.Color.White;
            this.traybutton.HoveredState.Parent = this.traybutton;
            this.traybutton.Location = new System.Drawing.Point(90, 131);
            this.traybutton.Name = "traybutton";
            this.traybutton.ShadowDecoration.Parent = this.traybutton;
            this.traybutton.Size = new System.Drawing.Size(180, 45);
            this.traybutton.TabIndex = 2;
            this.traybutton.Text = "Change Background";
            this.traybutton.Click += new System.EventHandler(this.traybutton_Click);
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.AutoSize = false;
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneLabel1.ForeColor = System.Drawing.Color.White;
            this.siticoneLabel1.Location = new System.Drawing.Point(0, 41);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(899, 28);
            this.siticoneLabel1.TabIndex = 3;
            this.siticoneLabel1.Text = "Settings Menu";
            this.siticoneLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.Controls.Add(this.siticoneLabel1);
            this.Controls.Add(this.traybutton);
            this.Name = "settings";
            this.Size = new System.Drawing.Size(899, 518);
            this.ResumeLayout(false);

        }

        #endregion
        private Siticone.UI.WinForms.SiticoneButton traybutton;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel1;
    }
}
