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

namespace SecurityControl
{
    public partial class Form1 : Form
    {
        Connection myConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                myConnection = new Connection("COM3", 9600);
                SerialPort mySerial = myConnection.GetConnection();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
