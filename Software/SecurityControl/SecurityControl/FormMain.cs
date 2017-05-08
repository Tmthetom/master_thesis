using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace SecurityControl
{
    public partial class FormMain : Form
    {
        static Arduino.Connection myConnection = new Arduino.Connection();
        UserControls.Overview overview = new UserControls.Overview();
        UserControls.Settings settings = new UserControls.Settings();
        UserControls.Connection connection = new UserControls.Connection(myConnection);
        UserControls.About about = new UserControls.About();

        public FormMain()
        {
            InitializeComponent();
            //bunifuFlatButtonOverview.
            //bunifuTransition1.ShowSync(bunifuFlatButtonOverview);
        }

        private void BunifuImageButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Menu Overview button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuFlatButtonOverview_Click(object sender, EventArgs e)
        {
            panelBody.Controls.Clear();
            panelBody.Controls.Add(overview);
            overview.Dock = DockStyle.Fill;
            overview.Show();
        }

        /// <summary>
        /// Menu Settings button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuFlatButtonSettings_Click(object sender, EventArgs e)
        {
            panelBody.Controls.Clear();
            panelBody.Controls.Add(settings);
            settings.Dock = DockStyle.Fill;
            settings.Show();
        }

        /// <summary>
        /// Menu Connection button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuFlatButtonConnection_Click(object sender, EventArgs e)
        {
            panelBody.Controls.Clear();
            panelBody.Controls.Add(connection);
            connection.Dock = DockStyle.Fill;
            connection.Show();
        }

        /// <summary>
        /// Menu About button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuFlatButtonAbout_Click(object sender, EventArgs e)
        {
            panelBody.Controls.Clear();
            panelBody.Controls.Add(about);
            about.Dock = DockStyle.Fill;
            about.Show();
        }
    }
}
