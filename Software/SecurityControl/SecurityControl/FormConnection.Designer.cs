namespace SecurityControl
{
    partial class FormConnection
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
            this.buttonConnection = new System.Windows.Forms.Button();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.comboBoxConnectionBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxConnectionPort = new System.Windows.Forms.ComboBox();
            this.labelConnectionBaudRate = new System.Windows.Forms.Label();
            this.labelConnectionPort = new System.Windows.Forms.Label();
            this.groupBoxConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnection
            // 
            this.buttonConnection.Location = new System.Drawing.Point(12, 122);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(326, 37);
            this.buttonConnection.TabIndex = 0;
            this.buttonConnection.Text = "Connect";
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.ButtonConnection_Click);
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.comboBoxConnectionBaudRate);
            this.groupBoxConnection.Controls.Add(this.comboBoxConnectionPort);
            this.groupBoxConnection.Controls.Add(this.labelConnectionBaudRate);
            this.groupBoxConnection.Controls.Add(this.labelConnectionPort);
            this.groupBoxConnection.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(326, 104);
            this.groupBoxConnection.TabIndex = 1;
            this.groupBoxConnection.TabStop = false;
            // 
            // comboBoxConnectionBaudRate
            // 
            this.comboBoxConnectionBaudRate.FormattingEnabled = true;
            this.comboBoxConnectionBaudRate.Location = new System.Drawing.Point(125, 59);
            this.comboBoxConnectionBaudRate.Name = "comboBoxConnectionBaudRate";
            this.comboBoxConnectionBaudRate.Size = new System.Drawing.Size(167, 21);
            this.comboBoxConnectionBaudRate.TabIndex = 3;
            // 
            // comboBoxConnectionPort
            // 
            this.comboBoxConnectionPort.FormattingEnabled = true;
            this.comboBoxConnectionPort.Location = new System.Drawing.Point(125, 28);
            this.comboBoxConnectionPort.Name = "comboBoxConnectionPort";
            this.comboBoxConnectionPort.Size = new System.Drawing.Size(167, 21);
            this.comboBoxConnectionPort.TabIndex = 2;
            // 
            // labelConnectionBaudRate
            // 
            this.labelConnectionBaudRate.AutoSize = true;
            this.labelConnectionBaudRate.Location = new System.Drawing.Point(26, 62);
            this.labelConnectionBaudRate.Name = "labelConnectionBaudRate";
            this.labelConnectionBaudRate.Size = new System.Drawing.Size(55, 13);
            this.labelConnectionBaudRate.TabIndex = 1;
            this.labelConnectionBaudRate.Text = "BaudRate";
            // 
            // labelConnectionPort
            // 
            this.labelConnectionPort.AutoSize = true;
            this.labelConnectionPort.Location = new System.Drawing.Point(26, 31);
            this.labelConnectionPort.Name = "labelConnectionPort";
            this.labelConnectionPort.Size = new System.Drawing.Size(26, 13);
            this.labelConnectionPort.TabIndex = 0;
            this.labelConnectionPort.Text = "Port";
            // 
            // FormConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 173);
            this.Controls.Add(this.groupBoxConnection);
            this.Controls.Add(this.buttonConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConnection_FormClosing);
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConnection;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label labelConnectionBaudRate;
        private System.Windows.Forms.Label labelConnectionPort;
        private System.Windows.Forms.ComboBox comboBoxConnectionBaudRate;
        private System.Windows.Forms.ComboBox comboBoxConnectionPort;
    }
}