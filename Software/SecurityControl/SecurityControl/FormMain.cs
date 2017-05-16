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

        #region Initialization

        public FormMain()
        {
            InitializeComponent();
            bunifuFlatButtonOverview.selected = true;
            BunifuFlatButtonOverview_Click(this, new EventArgs());
        }

        #endregion Initialization

        #region User Interface

        UserControls.Connection connection = new UserControls.Connection(myConnection);
        UserControls.Overview overview = new UserControls.Overview(myConnection);
        UserControls.Settings settings = new UserControls.Settings();
        UserControls.About about = new UserControls.About();

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

        /// <summary>
        /// Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuImageButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion User Interface

        #region Communication

        static Arduino.Connection myConnection = new Arduino.Connection();

        /// <summary>
        /// What method is called, when data is recieved
        /// </summary>
        private void InitDataReciever()
        {
            myConnection.SetDataReciever(SerialPort_DataReceived);
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort mySerial = sender as SerialPort;
                string indata = mySerial.ReadExisting();

                MethodInvoker action = delegate
                { /*textBoxOutput.Text += indata;*/ };
                //textBoxOutput.BeginInvoke(action);
            }
            catch
            {
                ;
            }
        }

        #endregion Communication

    }
}
