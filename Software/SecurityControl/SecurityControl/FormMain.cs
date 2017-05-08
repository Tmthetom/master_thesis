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
        UserControls.About about = new UserControls.About();
        UserControls.Connection connection = new UserControls.Connection();

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

        private void BunifuFlatButtonConnection_Click(object sender, EventArgs e)
        {
            panelBody.Controls.Clear();
            panelBody.Controls.Add(connection);
            connection.Dock = DockStyle.Fill;
            connection.Show();
        }

        private void BunifuFlatButtonAbout_Click(object sender, EventArgs e)
        {
            panelBody.Controls.Clear();
            panelBody.Controls.Add(about);
            about.Dock = DockStyle.Fill;
            about.Show();
        }
    }
}
