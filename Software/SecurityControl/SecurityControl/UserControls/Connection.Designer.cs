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
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDropdownPort = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuDropdownBaudRate = new Bunifu.Framework.UI.BunifuDropdown();
            this.labelPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerConnectionCheck = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "Connect";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = null;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(230, 332);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(241, 48);
            this.bunifuFlatButton1.TabIndex = 0;
            this.bunifuFlatButton1.Text = "Connect";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.BunifuFlatButton1_Click);
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
            this.timerConnectionCheck.Interval = 1100;
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
            this.Controls.Add(this.bunifuFlatButton1);
            this.Name = "Connection";
            this.Size = new System.Drawing.Size(705, 496);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdownPort;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdownBaudRate;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerConnectionCheck;
    }
}
