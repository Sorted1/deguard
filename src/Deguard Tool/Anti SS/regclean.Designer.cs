namespace Deguard_Tool
{
    partial class regclean
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
            this.siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.siticoneLabel2 = new Siticone.UI.WinForms.SiticoneLabel();
            this.clearButton = new Siticone.UI.WinForms.SiticoneButton();
            this.siticonePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.AutoSize = false;
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneLabel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.siticoneLabel1.Location = new System.Drawing.Point(226, 23);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(356, 39);
            this.siticoneLabel1.TabIndex = 16;
            this.siticoneLabel1.Text = "Registry Cleanup";
            this.siticoneLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.siticonePanel1.BorderRadius = 15;
            this.siticonePanel1.BorderThickness = 3;
            this.siticonePanel1.Controls.Add(this.siticoneLabel2);
            this.siticonePanel1.Controls.Add(this.clearButton);
            this.siticonePanel1.Location = new System.Drawing.Point(145, 3);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(500, 243);
            this.siticonePanel1.TabIndex = 17;
            // 
            // siticoneLabel2
            // 
            this.siticoneLabel2.AutoSize = false;
            this.siticoneLabel2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.siticoneLabel2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.siticoneLabel2.Location = new System.Drawing.Point(81, 97);
            this.siticoneLabel2.Name = "siticoneLabel2";
            this.siticoneLabel2.Size = new System.Drawing.Size(356, 47);
            this.siticoneLabel2.TabIndex = 14;
            this.siticoneLabel2.Text = "Cleans Up Some Places In The Registry Where Exes Will Show!";
            this.siticoneLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clearButton
            // 
            this.clearButton.BorderRadius = 9;
            this.clearButton.BorderThickness = 1;
            this.clearButton.CheckedState.Parent = this.clearButton;
            this.clearButton.CustomImages.Parent = this.clearButton;
            this.clearButton.FillColor = System.Drawing.Color.RoyalBlue;
            this.clearButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.clearButton.ForeColor = System.Drawing.Color.White;
            this.clearButton.HoveredState.Parent = this.clearButton;
            this.clearButton.Location = new System.Drawing.Point(162, 180);
            this.clearButton.Name = "clearButton";
            this.clearButton.ShadowDecoration.Parent = this.clearButton;
            this.clearButton.Size = new System.Drawing.Size(180, 45);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "Press To Clear";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // regclean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.Controls.Add(this.siticoneLabel1);
            this.Controls.Add(this.siticonePanel1);
            this.Name = "regclean";
            this.Size = new System.Drawing.Size(772, 249);
            this.siticonePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel1;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel2;
        private Siticone.UI.WinForms.SiticoneButton clearButton;
    }
}
