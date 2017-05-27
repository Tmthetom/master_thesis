namespace SecurityControl.UserControls
{
    partial class NotConnected
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
            this.labelNotConnected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNotConnected
            // 
            this.labelNotConnected.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNotConnected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.labelNotConnected.Location = new System.Drawing.Point(238, 221);
            this.labelNotConnected.Name = "labelNotConnected";
            this.labelNotConnected.Size = new System.Drawing.Size(233, 17);
            this.labelNotConnected.TabIndex = 8;
            this.labelNotConnected.Text = "No device connected";
            this.labelNotConnected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NotConnected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.labelNotConnected);
            this.Name = "NotConnected";
            this.Size = new System.Drawing.Size(705, 496);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNotConnected;
    }
}
