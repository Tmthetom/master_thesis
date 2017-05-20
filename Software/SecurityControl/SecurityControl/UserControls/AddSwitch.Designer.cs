namespace SecurityControl.UserControls
{
    partial class AddSwitch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSwitch));
            this.labelName = new System.Windows.Forms.Label();
            this.buttonBack = new Bunifu.Framework.UI.BunifuFlatButton();
            this.buttonAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Status = new System.Windows.Forms.Label();
            this.labelPin = new System.Windows.Forms.Label();
            this.textboxPin = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.SwitchState = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.labelName.Location = new System.Drawing.Point(249, 44);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(222, 22);
            this.labelName.TabIndex = 42;
            this.labelName.Text = "New Switch";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBack
            // 
            this.buttonBack.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBack.BorderRadius = 0;
            this.buttonBack.ButtonText = "Back";
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.DisabledColor = System.Drawing.Color.Gray;
            this.buttonBack.Iconcolor = System.Drawing.Color.Transparent;
            this.buttonBack.Iconimage = null;
            this.buttonBack.Iconimage_right = null;
            this.buttonBack.Iconimage_right_Selected = null;
            this.buttonBack.Iconimage_Selected = null;
            this.buttonBack.IconMarginLeft = 0;
            this.buttonBack.IconMarginRight = 0;
            this.buttonBack.IconRightVisible = true;
            this.buttonBack.IconRightZoom = 0D;
            this.buttonBack.IconVisible = true;
            this.buttonBack.IconZoom = 90D;
            this.buttonBack.IsTab = false;
            this.buttonBack.Location = new System.Drawing.Point(240, 429);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.buttonBack.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.buttonBack.OnHoverTextColor = System.Drawing.Color.White;
            this.buttonBack.selected = false;
            this.buttonBack.Size = new System.Drawing.Size(241, 48);
            this.buttonBack.TabIndex = 40;
            this.buttonBack.Text = "Back";
            this.buttonBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonBack.Textcolor = System.Drawing.Color.Black;
            this.buttonBack.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdd.BorderRadius = 0;
            this.buttonAdd.ButtonText = "Add";
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.DisabledColor = System.Drawing.Color.Gray;
            this.buttonAdd.Iconcolor = System.Drawing.Color.Transparent;
            this.buttonAdd.Iconimage = null;
            this.buttonAdd.Iconimage_right = null;
            this.buttonAdd.Iconimage_right_Selected = null;
            this.buttonAdd.Iconimage_Selected = null;
            this.buttonAdd.IconMarginLeft = 0;
            this.buttonAdd.IconMarginRight = 0;
            this.buttonAdd.IconRightVisible = true;
            this.buttonAdd.IconRightZoom = 0D;
            this.buttonAdd.IconVisible = true;
            this.buttonAdd.IconZoom = 90D;
            this.buttonAdd.IsTab = false;
            this.buttonAdd.Location = new System.Drawing.Point(240, 361);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.buttonAdd.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.buttonAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.buttonAdd.selected = false;
            this.buttonAdd.Size = new System.Drawing.Size(241, 48);
            this.buttonAdd.TabIndex = 51;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonAdd.Textcolor = System.Drawing.Color.Black;
            this.buttonAdd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Status.ForeColor = System.Drawing.Color.White;
            this.Status.Location = new System.Drawing.Point(35, 267);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(46, 17);
            this.Status.TabIndex = 56;
            this.Status.Text = "Status";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPin
            // 
            this.labelPin.AutoSize = true;
            this.labelPin.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPin.ForeColor = System.Drawing.Color.White;
            this.labelPin.Location = new System.Drawing.Point(35, 192);
            this.labelPin.Name = "labelPin";
            this.labelPin.Size = new System.Drawing.Size(27, 17);
            this.labelPin.TabIndex = 55;
            this.labelPin.Text = "Pin";
            this.labelPin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxPin
            // 
            this.textboxPin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxPin.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textboxPin.ForeColor = System.Drawing.Color.White;
            this.textboxPin.HintForeColor = System.Drawing.Color.White;
            this.textboxPin.HintText = "";
            this.textboxPin.isPassword = false;
            this.textboxPin.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.textboxPin.LineIdleColor = System.Drawing.Color.Gray;
            this.textboxPin.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.textboxPin.LineThickness = 3;
            this.textboxPin.Location = new System.Drawing.Point(176, 177);
            this.textboxPin.Margin = new System.Windows.Forms.Padding(4);
            this.textboxPin.Name = "textboxPin";
            this.textboxPin.Size = new System.Drawing.Size(486, 44);
            this.textboxPin.TabIndex = 54;
            this.textboxPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxName
            // 
            this.textboxName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textboxName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textboxName.ForeColor = System.Drawing.Color.White;
            this.textboxName.HintForeColor = System.Drawing.Color.White;
            this.textboxName.HintText = "";
            this.textboxName.isPassword = false;
            this.textboxName.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.textboxName.LineIdleColor = System.Drawing.Color.Gray;
            this.textboxName.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.textboxName.LineThickness = 3;
            this.textboxName.Location = new System.Drawing.Point(176, 101);
            this.textboxName.Margin = new System.Windows.Forms.Padding(4);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(486, 44);
            this.textboxName.TabIndex = 52;
            this.textboxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // SwitchState
            // 
            this.SwitchState.BackColor = System.Drawing.Color.Transparent;
            this.SwitchState.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SwitchState.BackgroundImage")));
            this.SwitchState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SwitchState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwitchState.Location = new System.Drawing.Point(619, 263);
            this.SwitchState.Name = "SwitchState";
            this.SwitchState.OffColor = System.Drawing.Color.Gray;
            this.SwitchState.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.SwitchState.Size = new System.Drawing.Size(43, 25);
            this.SwitchState.TabIndex = 57;
            this.SwitchState.Value = false;
            // 
            // AddSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(88)))), ((int)(((byte)(90)))));
            this.Controls.Add(this.SwitchState);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.labelPin);
            this.Controls.Add(this.textboxPin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxName);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonBack);
            this.Name = "AddSwitch";
            this.Size = new System.Drawing.Size(705, 496);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelName;
        private Bunifu.Framework.UI.BunifuFlatButton buttonBack;
        private Bunifu.Framework.UI.BunifuFlatButton buttonAdd;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label labelPin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textboxPin;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textboxName;
        private Bunifu.Framework.UI.BunifuiOSSwitch SwitchState;
    }
}
