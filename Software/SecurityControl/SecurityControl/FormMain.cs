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
    public partial class FormMain : Form
    {
        Connection myConnection;
        FormConnection myFormConnection;

        public FormMain()
        {
            InitializeComponent();
            InitializeForm();
            this.WindowState = FormWindowState.Minimized;
        }

        private void InitializeForm()
        {
            myFormConnection = new FormConnection(myConnection);
            myFormConnection.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
