using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecurityControl.Arduino;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace SecurityControl
{
    public partial class FormMain : Form
    {
        Connection arduino = new Connection();

        #region Initialization
        /// <summary>
        /// Initialize form after program start
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            InitDataReciever();
            InitConnectionOptions();
            FirstConnection();
        }

        /// <summary>
        /// Initialize form after successfull connection
        /// </summary>
        public void InitializeForm()
        {
            try
            {
                // Init
                treeView.Nodes.Clear();
                string instring;
                Regex regex = null;
                Match match = null;
                int[] numbers = null;
                string stringNumbers;
                string[] splitNumbers;

                // Get leds
                arduino.Send("GetLeds");
                instring = arduino.ReadLine();
                regex = new Regex(@"[a-zA-Z]*\[(.*)\]");
                match = regex.Match(instring);

                if (match.Success)
                {
                    stringNumbers = match.Groups[1].Value;
                    splitNumbers = stringNumbers.Split(',');
                    numbers = new int[splitNumbers.Length];
                    for (int i = 0; i < splitNumbers.Length; i++)
                    {
                        numbers[i] = Int32.Parse(splitNumbers[i]);
                    }
                }
                TreeNode leds = new TreeNode("Door sensors");
                foreach (int sensor in numbers)
                {
                    leds.Nodes.Add("Led pin: " + sensor);
                }
                treeView.Nodes.Add(leds);

                // Get doors
                arduino.Send("GetDoors");
                instring = arduino.ReadLine();
                regex = new Regex(@"[a-zA-Z]*\[(.*)\]");
                match = regex.Match(instring);

                if (match.Success)
                {
                    stringNumbers = match.Groups[1].Value;
                    splitNumbers = stringNumbers.Split(',');
                    numbers = new int[splitNumbers.Length];
                    for (int i = 0; i < splitNumbers.Length; i++)
                    {
                        numbers[i] = Int32.Parse(splitNumbers[i]);
                    }
                }
                TreeNode doors = new TreeNode("Door sensors");
                foreach (int sensor in numbers)
                {
                    doors.Nodes.Add("Senzor pin: " + sensor);
                }
                treeView.Nodes.Add(doors);

                // Expand all childs
                treeView.ExpandAll();
            }
            catch
            {
                ;
            }
        }
        #endregion Initialization

        #region Connection

        #region Init
        /// <summary>
        /// Connection when loading form
        /// </summary>
        private void InitConnectionOptions()
        {
            InitPorts();
            InitBaudRates();
        }
        
        /// <summary>
        /// Init ports for connection
        /// </summary>
        private void InitPorts()
        {
            // Initialize Ports
            string[] ports = SerialPort.GetPortNames();
            toolStripMenuItemPort.DropDownItems.Clear();
            foreach (string port in ports)  // Add items
            {
                ToolStripMenuItem item = new ToolStripMenuItem(port)
                {
                    CheckOnClick = true
                };
                item.Click += new EventHandler(ChangePortCheckOnClick);
                toolStripMenuItemPort.DropDownItems.Add(item);
            }
            if (ports.Length > 0)  // Select first if exists
            {
                ((ToolStripMenuItem)toolStripMenuItemPort.DropDownItems[0]).Checked = true;
            }
        }

        /// <summary>
        /// Init baudRates for connection
        /// </summary>
        private void InitBaudRates()
        {
            if (toolStripMenuItemBaudRate.DropDownItems.Count <= 0)
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
                toolStripMenuItemBaudRate.DropDownItems.Clear();
                foreach (string baudRate in baudRates)  // Add items
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(baudRate)
                    {
                        CheckOnClick = true
                    };
                    item.Click += new EventHandler(ChangeBaudRateCheckOnClick);
                    toolStripMenuItemBaudRate.DropDownItems.Add(item);
                }
                foreach (ToolStripMenuItem item in toolStripMenuItemBaudRate.DropDownItems)
                {
                    if (item.Text == "9600")
                    {
                        item.Checked = true;
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
                Connection();
            }
            catch
            {
                ;
            }
        }
        #endregion Init

        #region Method
        /// <summary>
        /// Connect to selected Port with selected BaudRate
        /// </summary>
        private void Connection()
        {
            try
            {
                // Close old connection
                arduino.Close();

                // Inform about connecting
                StatusStripConnecting();

                // Get selected Port
                string port = "";
                foreach (ToolStripMenuItem item in toolStripMenuItemPort.DropDownItems)
                {
                    if (item.Checked)
                    {
                        port = item.Text;
                        break;
                    }
                }

                // Get selected BaudRate
                int baudRate = 0;
                foreach (ToolStripMenuItem item in toolStripMenuItemBaudRate.DropDownItems)
                {
                    if (item.Checked)
                    {
                        baudRate = Int32.Parse(item.Text);
                        break;
                    }
                }

                // Try to connect
                arduino.SetConnection(port, baudRate);
                arduino.Open();

                // Initialize form after connection
                StatusStipConnected();
                InitializeForm();
            }
            catch
            {
                StatusStripNotConnected();
                throw;
            }
        }
        #endregion Method

        #region Buttons

        /// <summary>
        /// When Port clicked for selection change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePortCheckOnClick(object sender, EventArgs e)
        {
            // Reset checked
            foreach (ToolStripMenuItem item in toolStripMenuItemPort.DropDownItems)
            {
                item.Checked = false;
            }

            // Set new checked
            ToolStripMenuItem selectedItem = sender as ToolStripMenuItem;
            selectedItem.Checked = true;
        }

        /// <summary>
        /// When BaudRate clicked for selection change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeBaudRateCheckOnClick(object sender, EventArgs e)
        {
            // Reset checked
            foreach (ToolStripMenuItem item in toolStripMenuItemBaudRate.DropDownItems)
            {
                item.Checked = false;
            }

            // Set new checked
            ToolStripMenuItem selectedItem = sender as ToolStripMenuItem;
            selectedItem.Checked = true;
        }

        /// <summary>
        /// Connection button with error report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemConnect_Click(object sender, EventArgs e)
        {
            // Connect
            if (!arduino.IsOpen())
            {
                try
                {
                    InitPorts();
                    Connection();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            // Disconnect
            else
            {
                arduino.Close();
                StatusStripNotConnected();
            }
        }
        #endregion Buttons

        #endregion Connection

        #region Communication
        /// <summary>
        /// What method is called, when data is recieved
        /// </summary>
        private void InitDataReciever()
        {
            arduino.SetDataReciever(SerialPort_DataReceived);
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxOutput.Text = "";
                arduino.Send(textBoxInput.Text);
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
                { textBoxOutput.Text += indata; };
                textBoxOutput.BeginInvoke(action);
            }
            catch
            {
                ;
            }
        }
        #endregion Communication

        #region StatusStrip
        /// <summary>
        /// Set status strip into connecting state
        /// </summary>
        private void StatusStripConnecting()
        {
            statusStrip.BackColor = Color.Orange;
            toolStripStatusLabel.ForeColor = SystemColors.ControlText;
            toolStripStatusLabel.Text = "Connecting...";
        }

        /// <summary>
        /// Set status strip into not-connected state
        /// </summary>
        private void StatusStripNotConnected()
        {
            statusStrip.BackColor = Color.DarkRed;
            toolStripStatusLabel.ForeColor = Color.White;
            toolStripStatusLabel.Text = "Not connected...";
        }

        /// <summary>
        /// Set status strip into connected state
        /// </summary>
        private void StatusStipConnected()
        {
            statusStrip.BackColor = Color.YellowGreen;
            toolStripStatusLabel.ForeColor = SystemColors.ControlText;
            toolStripStatusLabel.Text = "Connected to " + arduino.GetPort() + " with " + arduino.GetBaudRate() + " baud rate.";
        }
        #endregion StatusStrip
    }
}
