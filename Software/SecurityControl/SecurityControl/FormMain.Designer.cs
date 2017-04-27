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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Vchodove");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Okna", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Sklep");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Prizemi");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Pohyb", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBaudRate = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.connectDisconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.DarkRed;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 488);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(874, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabel.Text = "Not connected...";
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.Location = new System.Drawing.Point(0, 24);
            this.treeView.Name = "treeView";
            treeNode1.Name = "Node2";
            treeNode1.Text = "Vchodove";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Okna";
            treeNode2.ToolTipText = "Rada okna";
            treeNode3.Name = "Node4";
            treeNode3.Text = "Sklep";
            treeNode4.Name = "Node7";
            treeNode4.Text = "Prizemi";
            treeNode5.Name = "Node1";
            treeNode5.Text = "Pohyb";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode5});
            this.treeView.Size = new System.Drawing.Size(264, 464);
            this.treeView.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectDisconnectToolStripMenuItem,
            this.toolStripMenuItemConnection});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(874, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemConnection
            // 
            this.toolStripMenuItemConnection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPort,
            this.toolStripMenuItemBaudRate});
            this.toolStripMenuItemConnection.Name = "toolStripMenuItemConnection";
            this.toolStripMenuItemConnection.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItemConnection.Text = "Settings";
            // 
            // toolStripMenuItemPort
            // 
            this.toolStripMenuItemPort.Name = "toolStripMenuItemPort";
            this.toolStripMenuItemPort.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemPort.Text = "Port";
            // 
            // toolStripMenuItemBaudRate
            // 
            this.toolStripMenuItemBaudRate.Name = "toolStripMenuItemBaudRate";
            this.toolStripMenuItemBaudRate.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemBaudRate.Text = "BaudRate";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(270, 212);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(592, 36);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(263, 254);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(611, 234);
            this.textBoxOutput.TabIndex = 4;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(263, 24);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(611, 182);
            this.textBoxInput.TabIndex = 5;
            // 
            // connectDisconnectToolStripMenuItem
            // 
            this.connectDisconnectToolStripMenuItem.Name = "connectDisconnectToolStripMenuItem";
            this.connectDisconnectToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.connectDisconnectToolStripMenuItem.Text = "Connect/Disconnect";
            this.connectDisconnectToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemConnect_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 510);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SecurityControl";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConnection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPort;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBaudRate;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ToolStripMenuItem connectDisconnectToolStripMenuItem;
    }
}

