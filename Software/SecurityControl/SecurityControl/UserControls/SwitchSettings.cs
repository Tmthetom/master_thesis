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
        #region Initialisation

        FormMain myParent;
        Switch mySwitch;
        Arduino.Operations myOperations;
        Functions.Functions myFunctions = new Functions.Functions();

        public SwitchSettings(FormMain parent, Switch switcher, Arduino.Operations operations)
        {
            myParent = parent;
            mySwitch = switcher;
            myOperations = operations;
            InitializeComponent();
            Fill();
        }

        /// <summary>
        /// Fill initial data
        /// </summary>
        private void Fill()
        {
            bunifuMaterialTextboxName.Text = mySwitch.CustomName;
            bunifuMaterialTextboxPin.Text = mySwitch.Pin.ToString();
            bunifuSwitchState.Value = mySwitch.State;
        }

        #endregion Initialisation

        #region Buttons

        /// <summary>
        /// Back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuBackButton_Click(object sender, EventArgs e)
        {
            myParent.panelBody.Controls.Clear();
            myParent.panelBody.Controls.Add(myParent.overview);
            myParent.overview.Dock = DockStyle.Fill;
            myParent.overview.Show();
        }

        /// <summary>
        /// Change name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuNameChangeButton_Click(object sender, EventArgs e)
        {
            String newName = bunifuMaterialTextboxName.Text.Trim();
            if (!newName.Equals(""))
            {
                myFunctions.Notification_Balloon("Sensor name changed.", "Successfully changed name from " + mySwitch.Name + " to " + newName + ".");
                myOperations.SetSensorName(mySwitch.Id, newName);
            }
            else
            {
                myFunctions.Notification_Balloon("Cannot change name", "Name cannot be empty.");
            }
        }

        /// <summary>
        /// Change pin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuPinChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int newPin = Int32.Parse(bunifuMaterialTextboxPin.Text);
                if (newPin >= 0 && newPin <= 100)
                {
                    myFunctions.Notification_Balloon("Sensor pin changed.", "Successfully changed pin from " + mySwitch.Pin + " to " + newPin + ".");
                    myOperations.SetSensorPin(mySwitch.Id, newPin);
                }
                else
                {
                    myFunctions.Notification_Balloon("Cannot change pin", "Selected pin is not in range from 0 to 100.");
                }
            }
            catch
            {
                myFunctions.Notification_Balloon("Cannot change pin", "Pin must be a number.");
            }
        }

        /// <summary>
        /// Change state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuSwitchState_OnValueChange(object sender, EventArgs e)
        {
            myOperations.SetSwitchState(mySwitch.Id, bunifuSwitchState.Value);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuDeleteButton_Click(object sender, EventArgs e)
        {
            myOperations.DeleteSensor(mySwitch.Id);
            myParent.overview.InitialiseComponentsFromArduino();
            BunifuBackButton_Click(this, new EventArgs());
        }

        #endregion Buttons
    }
}
