using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;

namespace SecurityControl.UserControls
{
    public partial class Connection : UserControl
    {
        #region Initialization

        FormMain myParent;
        Arduino.Connection myConnection;
        Functions.Functions myFunctions = new Functions.Functions();

        public Connection(FormMain parent, Arduino.Connection myConnection)
        {
            InitializeComponent();

            // Initialisation
            this.myConnection = myConnection;
            myParent = parent;
            InitializeValues();

            // Connection
            Connect();

            // Autocheck
            timerConnectionCheck.Enabled = true;
        }

        /// <summary>
        /// Connection when loading form
        /// </summary>
        private void InitializeValues()
        {
            InitPorts();
            InitBaudRates();
        }

        private int numberOfPorts = 0;

        /// <summary>
        /// Init ports for connection
        /// </summary>
        private void InitPorts()
        {
            // Get ports
            string[] ports = SerialPort.GetPortNames();

            // Save new ports if their are not same
            if (ports.Length != numberOfPorts)
            {
                bunifuDropdownPort.Clear();
                foreach (string port in ports) bunifuDropdownPort.AddItem(port);
                if (ports.Length > 0) bunifuDropdownPort.selectedIndex = 0;
                this.numberOfPorts = ports.Length;
            }
        }

        /// <summary>
        /// Autocalled when selected port changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuDropdownPort_onItemSelected(object sender, EventArgs e)
        {
            SetDeviceName(bunifuDropdownPort.selectedValue);
        }

        /// <summary>
        /// Get device name on selected port
        /// </summary>
        /// <param name="portName">Port name</param>
        private void SetDeviceName(string portName)
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort"))
                {
                    string[] portnames = SerialPort.GetPortNames();
                    List<ManagementBaseObject> ports = searcher.Get().Cast<ManagementBaseObject>().ToList();

                    foreach (ManagementBaseObject port in ports)
                    {
                        if (port["DeviceID"].ToString().Equals(portName))
                        {
                            labelDeviceName.Text = port["Description"].ToString();  // Hint: Win32_SerialPort class
                            break;
                        }
                    }
                }

            }
            catch
            {
                ;
            }
        }

        /// <summary>
        /// Init baudRates for connection
        /// </summary>
        private void InitBaudRates()
        {
            if (bunifuDropdownBaudRate.Items.Count() <= 0)
            {
                // Initialize BaudRates
                string[] baudRates = new string[] {
                    "300",
                    "1200",
                    "2400",
                    "4800",
                    "9600",
                    "19200",
                    "38400",
                    "57600",
                    "74880",
                    "115200",
                    "230400",
                    "250000",
                    "500000",
                    "1000000",
                    "2000000",
                };                
                foreach (string baudRate in baudRates) bunifuDropdownBaudRate.AddItem(baudRate);
                bunifuDropdownBaudRate.Items = baudRates;
                for (int i = 0; i < baudRates.Length; i++)
                {
                    if (bunifuDropdownBaudRate.Items[i] == "9600")
                    {
                        bunifuDropdownBaudRate.selectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Return name of connected device
        /// </summary>
        /// <returns>Name of device</returns>
        public string GetDeviceName()
        {
            return labelDeviceName.Text;
        }

        #endregion Initialization

        #region Connection

        /// <summary>
        /// Connect to selected Port with selected BaudRate
        /// </summary>
        private void Connect()
        {
            try
            {
                // Close old connection
                myConnection.Close();

                // Get selected Port
                string port = bunifuDropdownPort.selectedValue;

                // Get selected BaudRate
                int baudRate = Int32.Parse(bunifuDropdownBaudRate.selectedValue);

                // Try to connect
                myConnection.SetConnection(port, baudRate);
                myConnection.Open();

                // Unlock forms
                myParent.overview.Connected();
                myParent.features.Connected();

                // Initialize form after connection
                myParent.overview.InitialiseComponentsFromArduino();

                // Inform about successfull connection
                myFunctions.Notification_Balloon("Connected",
                    "Successfully connected to " + (labelDeviceName.Text.Equals("") ? "device" : labelDeviceName.Text) + " at " + myConnection.GetPort() + " with " + myConnection.GetBaudRate() + " baud rate.");
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("InvalidArgument"))
                {
                    myFunctions.Notification_Balloon("Connection failed",
                    "No device founded, please check connection and try it again.");
                }
                else
                {
                    myFunctions.Notification_Balloon("Connection failed",
                    "Cannot connect to selected port, please check connection and try it again.");
                }

                // Lock forms
                myParent.overview.NotConnected();
                myParent.features.NotConnected();
            }
        }

        /// <summary>
        /// Disconnect currently opened connection
        /// </summary>
        private void Disconnect()
        {
            try
            {
                // Close old connection
                myConnection.Close();

                // Inform about successfull connection
                myFunctions.Notification_Balloon("Disconnected",
                    "Successfully disconected from " + (labelDeviceName.Text.Equals("") ? "device" : labelDeviceName.Text) + " at " + myConnection.GetPort() + ".");

                // Lock forms
                myParent.overview.NotConnected();
                myParent.features.NotConnected();
            }
            catch
            {
                myFunctions.Notification_Balloon("Disconnection failed",
                    "Cannot disconnect from " + (labelDeviceName.Text.Equals("") ? "device" : labelDeviceName.Text) + " at " + myConnection.GetPort() + " with " + myConnection.GetBaudRate() + " baud rate. Please check connection and try it again.");
            }
        }

        /// <summary>
        /// Connect to selected port with selected baudRate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuConnecionButton_Click(object sender, EventArgs e)
        {
            if (bunifuConnectionButton.Text.Equals("Connect")) {
                Connect();
            }
            else
            {
                Disconnect();
                timerConnectionCheck.Interval = timerNotConnected;  // Set to not connected
                bunifuConnectionButton.Text = "Connect";
            }
        }

        private static int timerConnected = 1100;
        private static int timerNotConnected = 1000;

        /// <summary>
        /// Connection checker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerConnectionCheck_Tick(object sender, EventArgs e)
        {
            // If connection lost or not connected
            if (!myConnection.IsOpen())
            {
                // Scan for ports
                InitPorts();

                // Check if was connected before
                if (timerConnectionCheck.Interval == timerConnected)
                {
                    myFunctions.Notification_Balloon("Connectino lost",
                        "Arduino connection was lost, please check connection and try to connect manually.");
                    timerConnectionCheck.Interval = timerNotConnected;  // Set to not connected
                    bunifuConnectionButton.Text = "Connect";

                    // Lock forms
                    myParent.overview.NotConnected();
                    myParent.features.NotConnected();
                }
            }

            // If connected 
            else if (timerConnectionCheck.Interval != timerConnected)  // But was not connected before
            {
                timerConnectionCheck.Interval = timerConnected;  // Set to connected
                bunifuConnectionButton.Text = "Disconnect";
            }
        }

        #endregion Connection
    }
}
