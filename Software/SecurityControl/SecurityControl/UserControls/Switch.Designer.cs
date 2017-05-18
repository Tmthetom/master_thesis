namespace SecurityControl.UserControls
{
    partial class Switch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Switch));
            this.bunifuSeparator = new Bunifu.Framework.UI.BunifuSeparator();
            this.labelSwitchName = new System.Windows.Forms.Label();
            this.bunifuSwitchState = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.pictureBoxSettings = new System.Windows.Forms.PictureBox();
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
            this.bunifuSeparator.TabIndex = 13;
            this.bunifuSeparator.Transparency = 255;
            this.bunifuSeparator.Vertical = false;
            // 
            // labelSwitchName
            // 
            this.labelSwitchName.AutoSize = true;
            this.labelSwitchName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSwitchName.ForeColor = System.Drawing.Color.White;
            this.labelSwitchName.Location = new System.Drawing.Point(83, 13);
            this.labelSwitchName.Name = "labelSwitchName";
            this.labelSwitchName.Size = new System.Drawing.Size(111, 17);
            this.labelSwitchName.TabIndex = 16;
            this.labelSwitchName.Text = "Name of Switch";
            this.labelSwitchName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuSwitchState
            // 
            this.bunifuSwitchState.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSwitchState.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSwitchState.BackgroundImage")));
            this.bunifuSwitchState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSwitchState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSwitchState.Location = new System.Drawing.Point(0, 8);
            this.bunifuSwitchState.Name = "bunifuSwitchState";
            this.bunifuSwitchState.OffColor = System.Drawing.Color.Gray;
            this.bunifuSwitchState.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.bunifuSwitchState.Size = new System.Drawing.Size(43, 25);
            this.bunifuSwitchState.TabIndex = 15;
            this.bunifuSwitchState.Value = false;
            this.bunifuSwitchState.OnValueChange += new System.EventHandler(this.BunifuSwitchState_OnValueChange);
            // 
            // pictureBoxSettings
            // 
            this.pictureBoxSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSettings.Image = global::SecurityControl.Properties.Resources.controls;
            this.pictureBoxSettings.Location = new System.Drawing.Point(600, 8);
            this.pictureBoxSettings.Name = "pictureBoxSettings";
            this.pictureBoxSettings.Size = new System.Drawing.Size(30, 27);
            this.pictureBoxSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSettings.TabIndex = 24;
            this.pictureBoxSettings.TabStop = false;
            this.pictureBoxSettings.Click += new System.EventHandler(this.PictureBoxSettings_Click);
            // 
            // Switch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.pictureBoxSettings);
            this.Controls.Add(this.labelSwitchName);
            this.Controls.Add(this.bunifuSwitchState);
            this.Controls.Add(this.bunifuSeparator);
            this.Name = "Switch";
            this.Size = new System.Drawing.Size(630, 78);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator;
        private System.Windows.Forms.Label labelSwitchName;
        private Bunifu.Framework.UI.BunifuiOSSwitch bunifuSwitchState;
        private System.Windows.Forms.PictureBox pictureBoxSettings;
    }
}
