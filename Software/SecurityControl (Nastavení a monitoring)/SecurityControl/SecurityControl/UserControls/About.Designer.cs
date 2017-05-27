namespace SecurityControl.UserControls
{
    partial class About
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
            this.labelAbout = new System.Windows.Forms.Label();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.labelContact = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelContactEmail = new System.Windows.Forms.Label();
            this.labelContactNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAbout
            // 
            this.labelAbout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAbout.ForeColor = System.Drawing.Color.White;
            this.labelAbout.Location = new System.Drawing.Point(52, 61);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(595, 44);
            this.labelAbout.TabIndex = 0;
            this.labelAbout.Text = "This software was created by Tomáš Moravec as part of his master project and its " +
    "property of Technical University of Liberec.";
            // 
            // labelCurrentVersion
            // 
            this.labelCurrentVersion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrentVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.labelCurrentVersion.Location = new System.Drawing.Point(224, 346);
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            this.labelCurrentVersion.Size = new System.Drawing.Size(233, 17);
            this.labelCurrentVersion.TabIndex = 4;
            this.labelCurrentVersion.Text = "Current version:";
            this.labelCurrentVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelContact
            // 
            this.labelContact.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.labelContact.Location = new System.Drawing.Point(224, 194);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(233, 17);
            this.labelContact.TabIndex = 5;
            this.labelContact.Text = "Contact on Author:";
            this.labelContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.Location = new System.Drawing.Point(224, 390);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(233, 17);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelContactEmail
            // 
            this.labelContactEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelContactEmail.ForeColor = System.Drawing.Color.White;
            this.labelContactEmail.Location = new System.Drawing.Point(224, 273);
            this.labelContactEmail.Name = "labelContactEmail";
            this.labelContactEmail.Size = new System.Drawing.Size(233, 17);
            this.labelContactEmail.TabIndex = 7;
            this.labelContactEmail.Text = "moravec-tomas@seznam.cz";
            this.labelContactEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelContactNumber
            // 
            this.labelContactNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelContactNumber.ForeColor = System.Drawing.Color.White;
            this.labelContactNumber.Location = new System.Drawing.Point(224, 240);
            this.labelContactNumber.Name = "labelContactNumber";
            this.labelContactNumber.Size = new System.Drawing.Size(233, 17);
            this.labelContactNumber.TabIndex = 8;
            this.labelContactNumber.Text = "+420 776 006 865";
            this.labelContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.labelContactNumber);
            this.Controls.Add(this.labelContactEmail);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelContact);
            this.Controls.Add(this.labelCurrentVersion);
            this.Controls.Add(this.labelAbout);
            this.Name = "About";
            this.Size = new System.Drawing.Size(705, 496);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.Label labelCurrentVersion;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelContactEmail;
        private System.Windows.Forms.Label labelContactNumber;
    }
}
