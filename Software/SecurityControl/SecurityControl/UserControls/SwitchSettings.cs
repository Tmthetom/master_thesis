using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityControl.UserControls
{
    public partial class SwitchSettings : UserControl
    {
        FormMain myParent;
        Switch mySwitch;

        public SwitchSettings(FormMain parent, Switch switcher)
        {
            myParent = parent;
            mySwitch = switcher;
            InitializeComponent();
        }

        private void BunifuBackButton_Click(object sender, EventArgs e)
        {
            myParent.panelBody.Controls.Clear();
            myParent.panelBody.Controls.Add(myParent.overview);
            myParent.overview.Dock = DockStyle.Fill;
            myParent.overview.Show();
        }
    }
}
