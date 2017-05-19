namespace SecurityControl.UserControls
{
    partial class Features
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
            this.buttonAddSwitch = new Bunifu.Framework.UI.BunifuFlatButton();
            this.buttonAddSensor = new Bunifu.Framework.UI.BunifuFlatButton();
            this.labelNotConnected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAddSwitch
            // 
            this.buttonAddSwitch.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buttonAddSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.buttonAddSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddSwitch.BorderRadius = 0;
            this.buttonAddSwitch.ButtonText = "   Add Switch";
            this.buttonAddSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddSwitch.DisabledColor = System.Drawing.Color.Gray;
            this.buttonAddSwitch.Iconcolor = System.Drawing.Color.Transparent;
            this.buttonAddSwitch.Iconimage = global::SecurityControl.Properties.Resources.plus;
            this.buttonAddSwitch.Iconimage_right = null;
            this.buttonAddSwitch.Iconimage_right_Selected = null;
            this.buttonAddSwitch.Iconimage_Selected = null;
            this.buttonAddSwitch.IconMarginLeft = 0;
            this.buttonAddSwitch.IconMarginRight = 0;
            this.buttonAddSwitch.IconRightVisible = true;
            this.buttonAddSwitch.IconRightZoom = 0D;
            this.buttonAddSwitch.IconVisible = true;
            this.buttonAddSwitch.IconZoom = 40D;
            this.buttonAddSwitch.IsTab = false;
            this.buttonAddSwitch.Location = new System.Drawing.Point(32, 103);
            this.buttonAddSwitch.Name = "buttonAddSwitch";
            this.buttonAddSwitch.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.buttonAddSwitch.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.buttonAddSwitch.OnHoverTextColor = System.Drawing.Color.White;
            this.buttonAddSwitch.selected = false;
            this.buttonAddSwitch.Size = new System.Drawing.Size(634, 48);
            this.buttonAddSwitch.TabIndex = 1;
            this.buttonAddSwitch.Text = "   Add Switch";
            this.buttonAddSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddSwitch.Textcolor = System.Drawing.SystemColors.ControlText;
            this.buttonAddSwitch.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSwitch.Click += new System.EventHandler(this.ButtonAddSwitch_Click);
            // 
            // buttonAddSensor
            // 
            this.buttonAddSensor.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buttonAddSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.buttonAddSensor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddSensor.BorderRadius = 0;
            this.buttonAddSensor.ButtonText = "   Add Sensor";
            this.buttonAddSensor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddSensor.DisabledColor = System.Drawing.Color.Gray;
            this.buttonAddSensor.Iconcolor = System.Drawing.Color.Transparent;
            this.buttonAddSensor.Iconimage = global::SecurityControl.Properties.Resources.plus;
            this.buttonAddSensor.Iconimage_right = null;
            this.buttonAddSensor.Iconimage_right_Selected = null;
            this.buttonAddSensor.Iconimage_Selected = null;
            this.buttonAddSensor.IconMarginLeft = 0;
            this.buttonAddSensor.IconMarginRight = 0;
            this.buttonAddSensor.IconRightVisible = true;
            this.buttonAddSensor.IconRightZoom = 0D;
            this.buttonAddSensor.IconVisible = true;
            this.buttonAddSensor.IconZoom = 40D;
            this.buttonAddSensor.IsTab = false;
            this.buttonAddSensor.Location = new System.Drawing.Point(32, 35);
            this.buttonAddSensor.Name = "buttonAddSensor";
            this.buttonAddSensor.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.buttonAddSensor.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.buttonAddSensor.OnHoverTextColor = System.Drawing.Color.White;
            this.buttonAddSensor.selected = false;
            this.buttonAddSensor.Size = new System.Drawing.Size(634, 48);
            this.buttonAddSensor.TabIndex = 0;
            this.buttonAddSensor.Text = "   Add Sensor";
            this.buttonAddSensor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddSensor.Textcolor = System.Drawing.SystemColors.ControlText;
            this.buttonAddSensor.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSensor.Click += new System.EventHandler(this.ButtonAddSensor_Click);
            // 
            // labelNotConnected
            // 
            this.labelNotConnected.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNotConnected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.labelNotConnected.Location = new System.Drawing.Point(238, 221);
            this.labelNotConnected.Name = "labelNotConnected";
            this.labelNotConnected.Size = new System.Drawing.Size(233, 17);
            this.labelNotConnected.TabIndex = 7;
            this.labelNotConnected.Text = "No device connected";
            this.labelNotConnected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNotConnected.Visible = false;
            // 
            // Features
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.labelNotConnected);
            this.Controls.Add(this.buttonAddSwitch);
            this.Controls.Add(this.buttonAddSensor);
            this.Name = "Features";
            this.Size = new System.Drawing.Size(705, 496);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton buttonAddSensor;
        private Bunifu.Framework.UI.BunifuFlatButton buttonAddSwitch;
        private System.Windows.Forms.Label labelNotConnected;
    }
}
