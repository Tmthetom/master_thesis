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
    public partial class AddSwitch : UserControl
    {
        #region Initialisation

        FormMain myParent;
        Arduino.Operations myOperations;
        Functions.Functions myFunctions = new Functions.Functions();
        String stringOk = "OK";

        public AddSwitch(FormMain parent, Arduino.Operations operations)
        {
            InitializeComponent();

            myParent = parent;
            myOperations = operations;

            SwitchState.Value = false;
        }

        #endregion Initialisation

        #region Buttons

        /// <summary>
        /// Add new Sensor button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // Check Name
            String name = textboxName.Text.Trim();
            if (name.Equals(""))
            {
                myFunctions.Notification_Balloon("Adding error", "Name must be filled.");
                return;
            }
            else if (name.Length > 20)
            {
                myFunctions.Notification_Balloon("Adding error", "Maximum name length is 20 characters.");
            }

            // Check Pin
            int pin = -1;
            try
            {
                pin = Int32.Parse(textboxPin.Text.Trim());
            }
            catch
            {
                myFunctions.Notification_Balloon("Adding error", "Pin number must be a number.");
                return;
            }
            if (pin < 0 || pin > 100)
            {
                myFunctions.Notification_Balloon("Adding error", "Pin number must be number between 0 and 100.");
                return;
            }

            // Try do Add
            try
            {
                myOperations.AddSwitch(pin, name, SwitchState.Value);
            }
            catch
            {
                myFunctions.Notification_Balloon("Adding error", "Adding failed with unspecified error.");
                return;
            }

            // Check Response
            string response = myOperations.ReadLine();
            if (response.Equals(stringOk))
            {
                myFunctions.Notification_Balloon("New switch added", "Successfully added new switch.");
            }
            else
            {
                myFunctions.Notification_Balloon("Operation error", "There was an error in selected operation.");
                return;
            }

            // Refresh and return back
            myParent.overview.InitialiseComponentsFromArduino();
            ButtonBack_Click(this, new EventArgs());
        }

        /// <summary>
        /// Back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            myParent.panelBody.Controls.Clear();
            myParent.panelBody.Controls.Add(myParent.features);
            myParent.features.Dock = DockStyle.Fill;
            myParent.features.Show();
        }

        #endregion Buttons
    }
}
