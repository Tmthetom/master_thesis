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

        // Fuctions
        Functions.Functions myFunctions = new Functions.Functions();

        // Controls
        public UserControls.Connection connection;
        public UserControls.Overview overview;
        public UserControls.Features features;
        public UserControls.About about;

        // Delegate
        public delegate void AddDataDelegate(String myString);
        public AddDataDelegate myDelegate;
        public void AddDataMethod(String myString)
        {
            inData.AppendText(myString);
        }

        public FormMain()
        {
            InitializeComponent();

            // Event initialisation
            InitDataReciever();
            this.myDelegate = new AddDataDelegate(AddDataMethod);

            // Initialisation
            overview = new UserControls.Overview(this, myConnection);
            features = new UserControls.Features(this, myConnection);
            about = new UserControls.About();

            // Connection to Arduino
            connection = new UserControls.Connection(this, myConnection);

            // Select First Menu Item
            bunifuFlatButtonOverview.selected = true;
            BunifuFlatButtonOverview_Click(this, new EventArgs());
        }
        
        #endregion Initialization

        #region User Interface

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
        /// Features menu button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuFlatButtonFeatures_Click(object sender, EventArgs e)
        {
            panelBody.Controls.Clear();
            panelBody.Controls.Add(features);
            features.Dock = DockStyle.Fill;
            features.Show();
        }

        /// <summary>
        /// Connection menu button
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
        /// About menu button
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
        String inString;
        String message;

        /// <summary>
        /// What method is called, when data is recieved
        /// </summary>
        private void InitDataReciever()
        {
            myConnection.SetDataReciever(SerialPort_DataReceived);
            inData.TextChanged += new EventHandler(SensorStateChanged);
        }

        /// <summary>
        /// Arduino event reciever
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (myConnection.AutoReadLocked == false)
                {
                    inString = myConnection.ReadLine();
                    inData.Invoke(this.myDelegate, new Object[] { inString });
                }
            }
            catch
            {
                ;
            }
        }

        #endregion Communication

        #region Autocalled functions

        /// <summary>
        /// Called when sensor state changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SensorStateChanged(object sender, EventArgs e)
        {
            message = inData.Text;
            if (!message.Equals(""))
            {
                // Get sensor id and state
                Regex regex = new Regex(@"\(Id = ([0-9]+),State = ([0-1])\)");
                Match match = regex.Match(message);
                if (!match.Success) return;
                int id = 0;
                bool state = false;
                try
                {
                    id = Int32.Parse(match.Groups[1].Value);
                    state = (Int32.Parse(match.Groups[2].Value) == 0) ? false : true; ;
                }
                catch
                {
                    return;
                }

                // Get all sensors
                List < UserControls.Sensor > sensors = overview.myOperations.GetAllSensors();

                // Find sensor in message
                foreach (UserControls.Sensor sensor in sensors)
                {
                    if (sensor.Id == id)
                    {
                        // False = push-to-break = normally open
                        if (sensor.Type == false && state == false)
                        {
                            myFunctions.Notification_Balloon("Sensor state changed", "Sensor named " + sensor.CustomName + " of type push-to-break (normally open) is now closed.");
                        }
                        else if (sensor.Type == false && state == true)
                        {
                            myFunctions.Notification_Balloon("Sensor state changed", "Sensor named " + sensor.CustomName + " of type push-to-break (normally open) is now opened (normal state).");
                        }

                        // True = push-to-make = normally closed
                        else if (sensor.Type == true && state == true)  
                        {
                            myFunctions.Notification_Balloon("Sensor state changed", "Sensor named " + sensor.CustomName + " of type push-to-make (normally closed) is now opened.");
                        }
                        else
                        {
                            myFunctions.Notification_Balloon("Sensor state changed", "Sensor named " + sensor.CustomName + " of type push-to-make (normally closed) is now closed (normal state).");
                        }

                        // Reload form
                        overview.InitialiseComponentsFromArduino();
                        break;
                    }
                }

                inData.Text = "";
            }
        }

        #endregion Autocalled functions
    }
}
