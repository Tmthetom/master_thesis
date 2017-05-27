namespace SecurityControl.UserControls
{
    partial class Sensor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sensor));
            this.bunifuSeparator = new Bunifu.Framework.UI.BunifuSeparator();
            this.labelSensorName = new System.Windows.Forms.Label();
            this.labelSensorType = new System.Windows.Forms.Label();
            this.pictureBoxSettings = new System.Windows.Forms.PictureBox();
            this.bunifuSensorState = new Bunifu.Framework.UI.BunifuiOSSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuSeparator
            // 
            this.bunifuSeparator.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator.LineThickness = 1;
            this.bunifuSeparator.Location = new System.Drawing.Point(0, 43);
            this.bunifuSeparator.Name = "bunifuSeparator";
            this.bunifuSeparator.Size = new System.Drawing.Size(630, 35);
            this.bunifuSeparator.TabIndex = 14;
            this.bunifuSeparator.Transparency = 255;
            this.bunifuSeparator.Vertical = false;
            // 
            // labelSensorName
            // 
            this.labelSensorName.AutoSize = true;
            this.labelSensorName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSensorName.ForeColor = System.Drawing.Color.White;
            this.labelSensorName.Location = new System.Drawing.Point(83, 13);
            this.labelSensorName.Name = "labelSensorName";
            this.labelSensorName.Size = new System.Drawing.Size(109, 17);
            this.labelSensorName.TabIndex = 18;
            this.labelSensorName.Text = "Name of Sensor";
            this.labelSensorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSensorType
            // 
            this.labelSensorType.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSensorType.ForeColor = System.Drawing.Color.White;
            this.labelSensorType.Location = new System.Drawing.Point(377, 13);
            this.labelSensorType.Name = "labelSensorType";
            this.labelSensorType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSensorType.Size = new System.Drawing.Size(153, 17);
            this.labelSensorType.TabIndex = 21;
            this.labelSensorType.Text = "Type of Sensor";
            this.labelSensorType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxSettings
            // 
            this.pictureBoxSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSettings.Image = global::SecurityControl.Properties.Resources.controls;
            this.pictureBoxSettings.Location = new System.Drawing.Point(600, 8);
            this.pictureBoxSettings.Name = "pictureBoxSettings";
            this.pictureBoxSettings.Size = new System.Drawing.Size(30, 27);
            this.pictureBoxSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSettings.TabIndex = 23;
            this.pictureBoxSettings.TabStop = false;
            this.pictureBoxSettings.Click += new System.EventHandler(this.PictureBoxSettings_Click);
            // 
            // bunifuSensorState
            // 
            this.bunifuSensorState.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSensorState.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSensorState.BackgroundImage")));
            this.bunifuSensorState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSensorState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSensorState.Enabled = false;
            this.bunifuSensorState.Location = new System.Drawing.Point(0, 8);
            this.bunifuSensorState.Name = "bunifuSensorState";
            this.bunifuSensorState.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuSensorState.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.bunifuSensorState.Size = new System.Drawing.Size(43, 25);
            this.bunifuSensorState.TabIndex = 22;
            this.bunifuSensorState.Value = false;
            // 
            // Sensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.pictureBoxSettings);
            this.Controls.Add(this.bunifuSensorState);
            this.Controls.Add(this.labelSensorType);
            this.Controls.Add(this.labelSensorName);
            this.Controls.Add(this.bunifuSeparator);
            this.Name = "Sensor";
            this.Size = new System.Drawing.Size(630, 78);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator;
        private System.Windows.Forms.Label labelSensorName;
        private System.Windows.Forms.Label labelSensorType;
        private Bunifu.Framework.UI.BunifuiOSSwitch bunifuSensorState;
        private System.Windows.Forms.PictureBox pictureBoxSettings;
    }
}
