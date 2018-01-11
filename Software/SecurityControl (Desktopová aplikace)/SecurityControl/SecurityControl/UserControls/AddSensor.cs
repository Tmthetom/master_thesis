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
    public partial class AddSensor : UserControl
    {
        #region Initialisation

        FormMain myParent;
        Arduino.Operations myOperations;
        Functions.Functions myFunctions = new Functions.Functions();
        String stringOk = "OK";

        public AddSensor(FormMain parent, Arduino.Operations operations)
        {
            InitializeComponent();

            myParent = parent;
            myOperations = operations;

            dropDownPin.Items = Arduino.BoardPins.GetPins(myParent.connection.GetDeviceName());

            dropDownPin.selectedIndex = 0;
            dropDownType.selectedIndex = 0;
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
                pin = Int32.Parse(dropDownPin.selectedValue.Trim());
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

            // Check type
            bool type = false;
            if (dropDownType.selectedValue.Equals("Normaly closed type = NC = Push to make"))  // true = push-to-make
            {
                type = true;
            }
            else if (dropDownType.selectedValue.Equals("Normaly open type = NO = Push to break"))  // false = push-to-break
            {
                type = false;
            }
            else
            {
                myFunctions.Notification_Balloon("Adding error", "Wrong type selected.");
                return;
            }

            // Try do Add
            try
            {
                myOperations.AddSensor(pin, name, type);
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
                myFunctions.Notification_Balloon("New sensor added", "Successfully added new sensor.");
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
