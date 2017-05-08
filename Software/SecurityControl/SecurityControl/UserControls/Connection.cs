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
using SecurityControl.Functions;

namespace SecurityControl.UserControls
{
    public partial class Connection : UserControl
    {
        #region Initialization

        Arduino.Connection arduino = new Arduino.Connection();
        Functions.Functions functions = new Functions.Functions();

        public Connection()
        {
            InitializeComponent();
            InitializeValues();
            FirstConnection();
        }

        /// <summary>
        /// Connection when loading form
        /// </summary>
        private void InitializeValues()
        {
            InitPorts();
            InitBaudRates();
        }

        /// <summary>
        /// Init ports for connection
        /// </summary>
        private void InitPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            bunifuDropdownPort.Clear();
            foreach (string port in ports) bunifuDropdownPort.AddItem(port);
            if (ports.Length > 0) bunifuDropdownPort.selectedIndex = 0;
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
        /// First connection try, without error report
        /// </summary>
        private void FirstConnection()
        {
            try
            {
                Connect();
                functions.Notification_Balloon("Connection completed", 
                    "Successfully connected to " + arduino.GetPort() + " with " + arduino.GetBaudRate() + " baud rate.",
                    SecurityControl.Properties.Resources.icon);
            }
            catch
            {
                ;
            }
        }

        #endregion Initialization

        #region Method
        /// <summary>
        /// Connect to selected Port with selected BaudRate
        /// </summary>
        private void Connect()
        {
            try
            {
                // Close old connection
                arduino.Close();

                // Inform about connecting


                // Get selected Port
                string port = bunifuDropdownPort.selectedValue;

                // Get selected BaudRate
                int baudRate = Int32.Parse(bunifuDropdownBaudRate.selectedValue);

                // Try to connect
                arduino.SetConnection(port, baudRate);
                arduino.Open();

                // Initialize form after connection

            }
            catch
            {
                throw;
            }
        }
        #endregion Method
    }
}
