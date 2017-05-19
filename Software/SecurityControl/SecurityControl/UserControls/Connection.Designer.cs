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
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.timerConnectionCheck = new System.Windows.Forms.Timer(this.components);
            this.labelDevice = new System.Windows.Forms.Label();
            this.panelDevice = new System.Windows.Forms.Panel();
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.panelDevice.SuspendLayout();
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
            this.bunifuConnectionButton.Location = new System.Drawing.Point(230, 429);
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
            this.bunifuConnectionButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuConnectionButton.Click += new System.EventHandler(this.BunifuConnecionButton_Click);
            // 
            // bunifuDropdownPort
            // 
            this.bunifuDropdownPort.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdownPort.BorderRadius = 3;
            this.bunifuDropdownPort.ForeColor = System.Drawing.Color.White;
            this.bunifuDropdownPort.Items = new string[0];
            this.bunifuDropdownPort.Location = new System.Drawing.Point(267, 182);
            this.bunifuDropdownPort.Name = "bunifuDropdownPort";
            this.bunifuDropdownPort.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(32)))));
            this.bunifuDropdownPort.onHoverColor = System.Drawing.Color.Black;
            this.bunifuDropdownPort.selectedIndex = -1;
            this.bunifuDropdownPort.Size = new System.Drawing.Size(297, 35);
            this.bunifuDropdownPort.TabIndex = 1;
            this.bunifuDropdownPort.onItemSelected += new System.EventHandler(this.BunifuDropdownPort_onItemSelected);
            // 
            // bunifuDropdownBaudRate
            // 
            this.bunifuDropdownBaudRate.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdownBaudRate.BorderRadius = 3;
            this.bunifuDropdownBaudRate.ForeColor = System.Drawing.Color.White;
            this.bunifuDropdownBaudRate.Items = new string[0];
            this.bunifuDropdownBaudRate.Location = new System.Drawing.Point(267, 256);
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
            this.labelPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPort.ForeColor = System.Drawing.Color.White;
            this.labelPort.Location = new System.Drawing.Point(110, 192);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(35, 16);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port:";
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBaudRate.ForeColor = System.Drawing.Color.White;
            this.labelBaudRate.Location = new System.Drawing.Point(110, 264);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(69, 16);
            this.labelBaudRate.TabIndex = 4;
            this.labelBaudRate.Text = "Baud rate:";
            // 
            // timerConnectionCheck
            // 
            this.timerConnectionCheck.Interval = 1000;
            this.timerConnectionCheck.Tick += new System.EventHandler(this.TimerConnectionCheck_Tick);
            // 
            // labelDevice
            // 
            this.labelDevice.AutoSize = true;
            this.labelDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDevice.ForeColor = System.Drawing.Color.White;
            this.labelDevice.Location = new System.Drawing.Point(110, 120);
            this.labelDevice.Name = "labelDevice";
            this.labelDevice.Size = new System.Drawing.Size(54, 16);
            this.labelDevice.TabIndex = 7;
            this.labelDevice.Text = "Device:";
            // 
            // panelDevice
            // 
            this.panelDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panelDevice.Controls.Add(this.labelDeviceName);
            this.panelDevice.Location = new System.Drawing.Point(267, 110);
            this.panelDevice.Name = "panelDevice";
            this.panelDevice.Size = new System.Drawing.Size(297, 35);
            this.panelDevice.TabIndex = 8;
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDeviceName.ForeColor = System.Drawing.Color.White;
            this.labelDeviceName.Location = new System.Drawing.Point(8, 10);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(0, 16);
            this.labelDeviceName.TabIndex = 9;
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.panelDevice);
            this.Controls.Add(this.labelDevice);
            this.Controls.Add(this.labelBaudRate);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.bunifuDropdownBaudRate);
            this.Controls.Add(this.bunifuDropdownPort);
            this.Controls.Add(this.bunifuConnectionButton);
            this.Name = "Connection";
            this.Size = new System.Drawing.Size(705, 496);
            this.panelDevice.ResumeLayout(false);
            this.panelDevice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton bunifuConnectionButton;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdownPort;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdownBaudRate;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.Timer timerConnectionCheck;
        private System.Windows.Forms.Label labelDevice;
        private System.Windows.Forms.Panel panelDevice;
        private System.Windows.Forms.Label labelDeviceName;
    }
}
