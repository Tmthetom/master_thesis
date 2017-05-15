namespace SecurityControl.UserControls
{
    partial class Connection
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
            this.components = new System.ComponentModel.Container();
            this.bunifuConnectionButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDropdownPort = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuDropdownBaudRate = new Bunifu.Framework.UI.BunifuDropdown();
            this.labelPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerConnectionCheck = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bunifuConnectionButton
            // 
            this.bunifuConnectionButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.bunifuConnectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuConnectionButton.BorderRadius = 0;
            this.bunifuConnectionButton.ButtonText = "Connect";
            this.bunifuConnectionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuConnectionButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuConnectionButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuConnectionButton.Iconimage = null;
            this.bunifuConnectionButton.Iconimage_right = null;
            this.bunifuConnectionButton.Iconimage_right_Selected = null;
            this.bunifuConnectionButton.Iconimage_Selected = null;
            this.bunifuConnectionButton.IconMarginLeft = 0;
            this.bunifuConnectionButton.IconMarginRight = 0;
            this.bunifuConnectionButton.IconRightVisible = true;
            this.bunifuConnectionButton.IconRightZoom = 0D;
            this.bunifuConnectionButton.IconVisible = true;
            this.bunifuConnectionButton.IconZoom = 90D;
            this.bunifuConnectionButton.IsTab = false;
            this.bunifuConnectionButton.Location = new System.Drawing.Point(230, 332);
            this.bunifuConnectionButton.Name = "bunifuConnectionButton";
            this.bunifuConnectionButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.bunifuConnectionButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.bunifuConnectionButton.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuConnectionButton.selected = false;
            this.bunifuConnectionButton.Size = new System.Drawing.Size(241, 48);
            this.bunifuConnectionButton.TabIndex = 0;
            this.bunifuConnectionButton.Text = "Connect";
            this.bunifuConnectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuConnectionButton.Textcolor = System.Drawing.Color.Black;
            this.bunifuConnectionButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuConnectionButton.Click += new System.EventHandler(this.BunifuConnecionButton_Click);
            // 
            // bunifuDropdownPort
            // 
            this.bunifuDropdownPort.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdownPort.BorderRadius = 3;
            this.bunifuDropdownPort.ForeColor = System.Drawing.Color.White;
            this.bunifuDropdownPort.Items = new string[0];
            this.bunifuDropdownPort.Location = new System.Drawing.Point(268, 133);
            this.bunifuDropdownPort.Name = "bunifuDropdownPort";
            this.bunifuDropdownPort.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.bunifuDropdownPort.onHoverColor = System.Drawing.Color.Black;
            this.bunifuDropdownPort.selectedIndex = -1;
            this.bunifuDropdownPort.Size = new System.Drawing.Size(297, 35);
            this.bunifuDropdownPort.TabIndex = 1;
            // 
            // bunifuDropdownBaudRate
            // 
            this.bunifuDropdownBaudRate.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdownBaudRate.BorderRadius = 3;
            this.bunifuDropdownBaudRate.ForeColor = System.Drawing.Color.White;
            this.bunifuDropdownBaudRate.Items = new string[0];
            this.bunifuDropdownBaudRate.Location = new System.Drawing.Point(268, 202);
            this.bunifuDropdownBaudRate.Name = "bunifuDropdownBaudRate";
            this.bunifuDropdownBaudRate.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.bunifuDropdownBaudRate.onHoverColor = System.Drawing.Color.Black;
            this.bunifuDropdownBaudRate.selectedIndex = -1;
            this.bunifuDropdownBaudRate.Size = new System.Drawing.Size(297, 35);
            this.bunifuDropdownBaudRate.TabIndex = 2;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPort.ForeColor = System.Drawing.Color.White;
            this.labelPort.Location = new System.Drawing.Point(111, 142);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(40, 18);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(111, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Baud rate:";
            // 
            // timerConnectionCheck
            // 
            this.timerConnectionCheck.Interval = 1000;
            this.timerConnectionCheck.Tick += new System.EventHandler(this.TimerConnectionCheck_Tick);
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.bunifuDropdownBaudRate);
            this.Controls.Add(this.bunifuDropdownPort);
            this.Controls.Add(this.bunifuConnectionButton);
            this.Name = "Connection";
            this.Size = new System.Drawing.Size(705, 496);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton bunifuConnectionButton;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdownPort;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdownBaudRate;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerConnectionCheck;
    }
}
