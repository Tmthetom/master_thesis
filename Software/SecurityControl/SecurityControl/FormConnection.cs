using System;
using System.IO.Ports;
using System.Windows.Forms;
using SecurityControl.Arduino;

namespace SecurityControl
{
    public partial class FormConnection : Form
    {
        Form parent;
        Connection myConnection;

        /// <summary>
        /// Initialize form
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="myConnection"></param>
        public FormConnection(Form parent, Connection myConnection)
        {
            InitializeComponent();
            this.parent = parent;
            InitializeForm(myConnection);
        }

        /// <summary>
        /// Initialize form components
        /// </summary>
        /// <param name="myConnection"></param>
        private void InitializeForm(Connection myConnection)
        {
            // Initialize Connection
            this.myConnection = myConnection;

            // Initialize Ports
            string[] ports = SerialPort.GetPortNames();
            comboBoxConnectionPort.Items.Clear();
            comboBoxConnectionPort.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comboBoxConnectionPort.SelectedIndex = 0;
            }

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
            comboBoxConnectionBaudRate.Items.Clear();
            comboBoxConnectionBaudRate.Items.AddRange(baudRates);
            int i = comboBoxConnectionBaudRate.Items.IndexOf("9600");
            comboBoxConnectionBaudRate.SelectedIndex = i;
        }

        /// <summary>
        /// Connect to port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnection_Click(object sender, EventArgs e)
        {
            try
            {
                // Get connection informations
                string port = comboBoxConnectionPort.Text;
                int baudRate = Int32.Parse(comboBoxConnectionBaudRate.Text);

                // Try to connect
                myConnection = new Connection(port, baudRate);

                // Restor parent and hide connection form
                parent.WindowState = FormWindowState.Normal;
                this.Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// When form closing, close whole application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
