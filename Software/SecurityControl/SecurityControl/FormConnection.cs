using System;
using System.IO.Ports;
using System.Windows.Forms;
using SecurityControl.Arduino;

namespace SecurityControl
{
    public partial class FormConnection : Form
    {
        Connection myConnection;

        public FormConnection(Connection myConnection)
        {
            InitializeComponent();
            InitializeForm(myConnection);
        }

        private void InitializeForm(Connection myConnection)
        {
            // Initialize Connection
            this.myConnection = myConnection;

            // Initialize Port
            string[] ports = SerialPort.GetPortNames();
            comboBoxConnectionPort.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comboBoxConnectionPort.SelectedIndex = 0;
            }

            // Initialize BaudRate
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
            comboBoxConnectionBaudRate.Items.AddRange(baudRates);
            int i = comboBoxConnectionBaudRate.Items.IndexOf("9600");
            comboBoxConnectionBaudRate.SelectedIndex = i;
        }

        private void ButtonConnection_Click(object sender, EventArgs e)
        {
            try
            {
                string port = comboBoxConnectionPort.Text;
                int baudRate = Int32.Parse(comboBoxConnectionBaudRate.Text);

                myConnection = new Connection(port, baudRate);
                SerialPort mySerial = myConnection.GetConnection();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
