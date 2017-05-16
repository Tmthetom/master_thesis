namespace SecurityControl.UserControls
{
    partial class SwitchSettings
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
            this.bunifuBackButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // bunifuBackButton
            // 
            this.bunifuBackButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.bunifuBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuBackButton.BorderRadius = 0;
            this.bunifuBackButton.ButtonText = "Back";
            this.bunifuBackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuBackButton.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuBackButton.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuBackButton.Iconimage = null;
            this.bunifuBackButton.Iconimage_right = null;
            this.bunifuBackButton.Iconimage_right_Selected = null;
            this.bunifuBackButton.Iconimage_Selected = null;
            this.bunifuBackButton.IconMarginLeft = 0;
            this.bunifuBackButton.IconMarginRight = 0;
            this.bunifuBackButton.IconRightVisible = true;
            this.bunifuBackButton.IconRightZoom = 0D;
            this.bunifuBackButton.IconVisible = true;
            this.bunifuBackButton.IconZoom = 90D;
            this.bunifuBackButton.IsTab = false;
            this.bunifuBackButton.Location = new System.Drawing.Point(230, 429);
            this.bunifuBackButton.Name = "bunifuBackButton";
            this.bunifuBackButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.bunifuBackButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.bunifuBackButton.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuBackButton.selected = false;
            this.bunifuBackButton.Size = new System.Drawing.Size(241, 48);
            this.bunifuBackButton.TabIndex = 7;
            this.bunifuBackButton.Text = "Back";
            this.bunifuBackButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuBackButton.Textcolor = System.Drawing.Color.Black;
            this.bunifuBackButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuBackButton.Click += new System.EventHandler(this.BunifuBackButton_Click);
            // 
            // SwitchSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.bunifuBackButton);
            this.Name = "SwitchSettings";
            this.Size = new System.Drawing.Size(705, 496);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton bunifuBackButton;
    }
}
