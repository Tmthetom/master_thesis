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
    }
}
