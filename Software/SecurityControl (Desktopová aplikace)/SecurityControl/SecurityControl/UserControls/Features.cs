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
    public partial class Features : UserControl
    {
        #region Initialisation

        FormMain myParent;
        Arduino.Connection myConnection;
        Arduino.Operations myOperations;

        public Features(FormMain parent, Arduino.Connection connection)
        {
            InitializeComponent();

            myParent = parent;
            this.myConnection = connection;
            myOperations = new Arduino.Operations(myParent, myConnection);
        }

        /// <summary>
        /// When program not connected
        /// </summary>
        public void NotConnected()
        {
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }

            labelNotConnected.Visible = true;
        }

        /// <summary>
        /// When program connected
        /// </summary>
        public void Connected()
        {
            foreach (Control control in this.Controls)
            {
                control.Visible = true;
            }

            labelNotConnected.Visible = false;
        }

        #endregion Initialisation

        #region Functions

        /// <summary>
        /// Add Sensor feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddSensor_Click(object sender, EventArgs e)
        {
            AddSensor addSensor = new AddSensor(myParent, myOperations);
            myParent.panelBody.Controls.Clear();
            myParent.panelBody.Controls.Add(addSensor);
            addSensor.Dock = DockStyle.Fill;
            addSensor.Show();
        }

        /// <summary>
        /// Add Switch feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddSwitch_Click(object sender, EventArgs e)
        {
            AddSwitch addSwitch = new AddSwitch(myParent, myOperations);
            myParent.panelBody.Controls.Clear();
            myParent.panelBody.Controls.Add(addSwitch);
            addSwitch.Dock = DockStyle.Fill;
            addSwitch.Show();
        }

        /// <summary>
        /// Reload all devices from Arduino
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReloadDevices_Click(object sender, EventArgs e)
        {
            myParent.overview.InitialiseComponentsFromArduino();
        }

        #endregion Functions
    }
}
