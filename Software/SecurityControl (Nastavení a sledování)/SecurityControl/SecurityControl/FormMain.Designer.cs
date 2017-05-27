namespace SecurityControl
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.inData = new System.Windows.Forms.TextBox();
            this.bunifuFlatButtonAbout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButtonConnection = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButtonFeatures = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.bunifuFlatButtonOverview = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.bunifuImageButtonExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabelHeader = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControlHeader = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControlHeaderText = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButtonExit)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.Window;
            this.panelMenu.Controls.Add(this.inData);
            this.panelMenu.Controls.Add(this.bunifuFlatButtonAbout);
            this.panelMenu.Controls.Add(this.bunifuFlatButtonConnection);
            this.panelMenu.Controls.Add(this.bunifuFlatButtonFeatures);
            this.panelMenu.Controls.Add(this.pictureBoxLogo);
            this.panelMenu.Controls.Add(this.bunifuFlatButtonOverview);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 39);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(245, 496);
            this.panelMenu.TabIndex = 6;
            // 
            // inData
            // 
            this.inData.Location = new System.Drawing.Point(10, -20);
            this.inData.Multiline = true;
            this.inData.Name = "inData";
            this.inData.Size = new System.Drawing.Size(234, 10);
            this.inData.TabIndex = 4;
            this.inData.Visible = false;
            this.inData.TextChanged += new System.EventHandler(this.SensorStateChanged);
            // 
            // bunifuFlatButtonAbout
            // 
            this.bunifuFlatButtonAbout.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuFlatButtonAbout.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButtonAbout.BorderRadius = 0;
            this.bunifuFlatButtonAbout.ButtonText = "About";
            this.bunifuFlatButtonAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButtonAbout.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButtonAbout.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonAbout.Iconimage = null;
            this.bunifuFlatButtonAbout.Iconimage_right = null;
            this.bunifuFlatButtonAbout.Iconimage_right_Selected = null;
            this.bunifuFlatButtonAbout.Iconimage_Selected = null;
            this.bunifuFlatButtonAbout.IconMarginLeft = 0;
            this.bunifuFlatButtonAbout.IconMarginRight = 0;
            this.bunifuFlatButtonAbout.IconRightVisible = true;
            this.bunifuFlatButtonAbout.IconRightZoom = 0D;
            this.bunifuFlatButtonAbout.IconVisible = true;
            this.bunifuFlatButtonAbout.IconZoom = 90D;
            this.bunifuFlatButtonAbout.IsTab = true;
            this.bunifuFlatButtonAbout.Location = new System.Drawing.Point(0, 424);
            this.bunifuFlatButtonAbout.Name = "bunifuFlatButtonAbout";
            this.bunifuFlatButtonAbout.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonAbout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.bunifuFlatButtonAbout.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButtonAbout.selected = false;
            this.bunifuFlatButtonAbout.Size = new System.Drawing.Size(246, 49);
            this.bunifuFlatButtonAbout.TabIndex = 3;
            this.bunifuFlatButtonAbout.Text = "About";
            this.bunifuFlatButtonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButtonAbout.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButtonAbout.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuFlatButtonAbout.Click += new System.EventHandler(this.BunifuFlatButtonAbout_Click);
            // 
            // bunifuFlatButtonConnection
            // 
            this.bunifuFlatButtonConnection.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuFlatButtonConnection.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButtonConnection.BorderRadius = 0;
            this.bunifuFlatButtonConnection.ButtonText = "Connection";
            this.bunifuFlatButtonConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButtonConnection.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButtonConnection.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonConnection.Iconimage = null;
            this.bunifuFlatButtonConnection.Iconimage_right = null;
            this.bunifuFlatButtonConnection.Iconimage_right_Selected = null;
            this.bunifuFlatButtonConnection.Iconimage_Selected = null;
            this.bunifuFlatButtonConnection.IconMarginLeft = 0;
            this.bunifuFlatButtonConnection.IconMarginRight = 0;
            this.bunifuFlatButtonConnection.IconRightVisible = true;
            this.bunifuFlatButtonConnection.IconRightZoom = 0D;
            this.bunifuFlatButtonConnection.IconVisible = true;
            this.bunifuFlatButtonConnection.IconZoom = 90D;
            this.bunifuFlatButtonConnection.IsTab = true;
            this.bunifuFlatButtonConnection.Location = new System.Drawing.Point(0, 339);
            this.bunifuFlatButtonConnection.Name = "bunifuFlatButtonConnection";
            this.bunifuFlatButtonConnection.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonConnection.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.bunifuFlatButtonConnection.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButtonConnection.selected = false;
            this.bunifuFlatButtonConnection.Size = new System.Drawing.Size(246, 49);
            this.bunifuFlatButtonConnection.TabIndex = 2;
            this.bunifuFlatButtonConnection.Text = "Connection";
            this.bunifuFlatButtonConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButtonConnection.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButtonConnection.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuFlatButtonConnection.Click += new System.EventHandler(this.BunifuFlatButtonConnection_Click);
            // 
            // bunifuFlatButtonFeatures
            // 
            this.bunifuFlatButtonFeatures.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuFlatButtonFeatures.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonFeatures.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButtonFeatures.BorderRadius = 0;
            this.bunifuFlatButtonFeatures.ButtonText = "Features";
            this.bunifuFlatButtonFeatures.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButtonFeatures.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButtonFeatures.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonFeatures.Iconimage = null;
            this.bunifuFlatButtonFeatures.Iconimage_right = null;
            this.bunifuFlatButtonFeatures.Iconimage_right_Selected = null;
            this.bunifuFlatButtonFeatures.Iconimage_Selected = null;
            this.bunifuFlatButtonFeatures.IconMarginLeft = 0;
            this.bunifuFlatButtonFeatures.IconMarginRight = 0;
            this.bunifuFlatButtonFeatures.IconRightVisible = true;
            this.bunifuFlatButtonFeatures.IconRightZoom = 0D;
            this.bunifuFlatButtonFeatures.IconVisible = true;
            this.bunifuFlatButtonFeatures.IconZoom = 90D;
            this.bunifuFlatButtonFeatures.IsTab = true;
            this.bunifuFlatButtonFeatures.Location = new System.Drawing.Point(0, 284);
            this.bunifuFlatButtonFeatures.Name = "bunifuFlatButtonFeatures";
            this.bunifuFlatButtonFeatures.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonFeatures.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.bunifuFlatButtonFeatures.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButtonFeatures.selected = false;
            this.bunifuFlatButtonFeatures.Size = new System.Drawing.Size(246, 49);
            this.bunifuFlatButtonFeatures.TabIndex = 1;
            this.bunifuFlatButtonFeatures.Text = "Features";
            this.bunifuFlatButtonFeatures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButtonFeatures.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButtonFeatures.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuFlatButtonFeatures.Click += new System.EventHandler(this.BunifuFlatButtonFeatures_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::SecurityControl.Properties.Resources.FM_ctverce;
            this.pictureBoxLogo.Location = new System.Drawing.Point(63, 53);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // bunifuFlatButtonOverview
            // 
            this.bunifuFlatButtonOverview.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.bunifuFlatButtonOverview.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonOverview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButtonOverview.BorderRadius = 0;
            this.bunifuFlatButtonOverview.ButtonText = "Overview";
            this.bunifuFlatButtonOverview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButtonOverview.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButtonOverview.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonOverview.Iconimage = null;
            this.bunifuFlatButtonOverview.Iconimage_right = null;
            this.bunifuFlatButtonOverview.Iconimage_right_Selected = null;
            this.bunifuFlatButtonOverview.Iconimage_Selected = null;
            this.bunifuFlatButtonOverview.IconMarginLeft = 0;
            this.bunifuFlatButtonOverview.IconMarginRight = 0;
            this.bunifuFlatButtonOverview.IconRightVisible = true;
            this.bunifuFlatButtonOverview.IconRightZoom = 0D;
            this.bunifuFlatButtonOverview.IconVisible = true;
            this.bunifuFlatButtonOverview.IconZoom = 90D;
            this.bunifuFlatButtonOverview.IsTab = true;
            this.bunifuFlatButtonOverview.Location = new System.Drawing.Point(0, 229);
            this.bunifuFlatButtonOverview.Name = "bunifuFlatButtonOverview";
            this.bunifuFlatButtonOverview.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButtonOverview.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.bunifuFlatButtonOverview.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButtonOverview.selected = false;
            this.bunifuFlatButtonOverview.Size = new System.Drawing.Size(246, 49);
            this.bunifuFlatButtonOverview.TabIndex = 0;
            this.bunifuFlatButtonOverview.Text = "Overview";
            this.bunifuFlatButtonOverview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButtonOverview.Textcolor = System.Drawing.Color.Black;
            this.bunifuFlatButtonOverview.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuFlatButtonOverview.Click += new System.EventHandler(this.BunifuFlatButtonOverview_Click);
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(245, 39);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(705, 496);
            this.panelBody.TabIndex = 4;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.panelHeader.Controls.Add(this.bunifuImageButtonExit);
            this.panelHeader.Controls.Add(this.bunifuCustomLabelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(950, 39);
            this.panelHeader.TabIndex = 0;
            // 
            // bunifuImageButtonExit
            // 
            this.bunifuImageButtonExit.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButtonExit.Image = global::SecurityControl.Properties.Resources.multiply;
            this.bunifuImageButtonExit.ImageActive = null;
            this.bunifuImageButtonExit.InitialImage = null;
            this.bunifuImageButtonExit.Location = new System.Drawing.Point(918, 9);
            this.bunifuImageButtonExit.Name = "bunifuImageButtonExit";
            this.bunifuImageButtonExit.Size = new System.Drawing.Size(20, 20);
            this.bunifuImageButtonExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButtonExit.TabIndex = 0;
            this.bunifuImageButtonExit.TabStop = false;
            this.bunifuImageButtonExit.Zoom = 20;
            this.bunifuImageButtonExit.Click += new System.EventHandler(this.BunifuImageButtonExit_Click);
            // 
            // bunifuCustomLabelHeader
            // 
            this.bunifuCustomLabelHeader.AutoSize = true;
            this.bunifuCustomLabelHeader.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bunifuCustomLabelHeader.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabelHeader.Location = new System.Drawing.Point(12, 9);
            this.bunifuCustomLabelHeader.Name = "bunifuCustomLabelHeader";
            this.bunifuCustomLabelHeader.Size = new System.Drawing.Size(356, 20);
            this.bunifuCustomLabelHeader.TabIndex = 0;
            this.bunifuCustomLabelHeader.Text = "Technical University of Liberec - Security control";
            // 
            // bunifuDragControlHeader
            // 
            this.bunifuDragControlHeader.Fixed = true;
            this.bunifuDragControlHeader.Horizontal = true;
            this.bunifuDragControlHeader.TargetControl = this.panelHeader;
            this.bunifuDragControlHeader.Vertical = true;
            // 
            // bunifuDragControlHeaderText
            // 
            this.bunifuDragControlHeaderText.Fixed = true;
            this.bunifuDragControlHeaderText.Horizontal = true;
            this.bunifuDragControlHeaderText.TargetControl = this.bunifuCustomLabelHeader;
            this.bunifuDragControlHeaderText.Vertical = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(950, 535);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelHeader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButtonExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButtonOverview;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelHeader;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButtonFeatures;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButtonAbout;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButtonConnection;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabelHeader;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButtonExit;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControlHeader;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControlHeaderText;
        public System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.TextBox inData;
    }
}

