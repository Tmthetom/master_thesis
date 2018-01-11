﻿using System;
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
    public partial class SensorSettings : UserControl
    {
        #region Initialisation

        FormMain myParent;
        Sensor mySensor;
        Arduino.Operations myOperations;
        Functions.Functions myFunctions = new Functions.Functions();
        String stringOk = "OK";

        public SensorSettings(FormMain parent, Sensor sensor, Arduino.Operations operations)
        {
            InitializeComponent();

            myParent = parent;
            mySensor = sensor;
            myOperations = operations;
            Fill();
        }

        /// <summary>
        /// Fill initial data
        /// </summary>
        private void Fill()
        {
            bunifuMaterialTextboxName.Text = mySensor.CustomName;
            bunifuDropdownType.selectedIndex = (mySensor.Type == false) ? 0 : 1;

            dropDownPin.Items = Arduino.BoardPins.GetPins(myParent.connection.GetDeviceName());
            dropDownPin.selectedIndex = dropDownPin.Items.ToList().IndexOf(mySensor.Pin.ToString());
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
                // Check maximum length
                if (newName.Length > 20)
                {
                    myFunctions.Notification_Balloon("Cannot change name", "Maximum length of name is 20 characters.");
                    return;
                }

                // Do Set
                string oldName = mySensor.Name;
                myOperations.SetSensorName(mySensor.Id, newName);

                // Check response
                string response = myOperations.ReadLine();
                if (response.Equals(stringOk))
                {
                    myFunctions.Notification_Balloon("Sensor name changed", "Successfully changed name from " + oldName + " to " + newName + ".");
                    myParent.overview.InitialiseComponentsFromArduino();
                }
                else
                {
                    myFunctions.Notification_Balloon("Operation error", "There was an error in selected operation.");
                }
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
                int newPin = Int32.Parse(dropDownPin.selectedValue.Trim());
                if (newPin >= 0 && newPin <= 100)
                {
                    int oldPin = mySensor.Pin;
                    myOperations.SetSensorPin(mySensor.Id, newPin);

                    // Check response
                    string response = myOperations.ReadLine();
                    if (response.Equals(stringOk))
                    {
                        myFunctions.Notification_Balloon("Sensor pin changed", "Successfully changed pin from " + oldPin + " to " + newPin + ".");
                        myParent.overview.InitialiseComponentsFromArduino();
                    }
                    else
                    {
                        myFunctions.Notification_Balloon("Operation error", "There was an error in selected operation.");
                    }
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
        /// Change type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuTypeChangeButton_Click(object sender, EventArgs e)
        {
            String newType = bunifuDropdownType.selectedValue;

            if (newType.Equals("Normaly closed type = NC = Push to make"))  // true = push-to-make
            {
                myOperations.SetSensorType(mySensor.Id, true);

                // Check Response
                string response = myOperations.ReadLine();
                if (response.Equals(stringOk))
                {
                    myFunctions.Notification_Balloon("Sensor type changed", "Successfully change type to '" + newType + "'.");
                    myParent.overview.InitialiseComponentsFromArduino();
                }
                else
                {
                    myFunctions.Notification_Balloon("Operation error", "There was an error in selected operation.");
                }
            }
            else if (newType.Equals("Normaly open type = NO = Push to break"))  // false = push-to-break
            {
                myOperations.SetSensorType(mySensor.Id, false);

                // Check Response
                string response = myOperations.ReadLine();
                if (response.Equals(stringOk))
                {
                    myFunctions.Notification_Balloon("Sensor type changed", "Successfully change type to '" + newType + "'.");
                    myParent.overview.InitialiseComponentsFromArduino();
                }
                else
                {
                    myFunctions.Notification_Balloon("Operation error", "There was an error in selected operation.");
                }
            }
            else
            {
                myFunctions.Notification_Balloon("Cannot change type", "Wrong type of sensor selected.");
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuDeleteButton_Click(object sender, EventArgs e)
        {
            myOperations.DeleteSensor(mySensor.Id);
            
            // Check Response
            string response = myOperations.ReadLine();
            if (response.Equals(stringOk))
            {
                myFunctions.Notification_Balloon("Successfully deleted", "Sensor was deleted from Arduino.");
                myParent.overview.InitialiseComponentsFromArduino();
            }
            else
            {
                myFunctions.Notification_Balloon("Operation error", "There was an error in selected operation.");
            }

            // Return back to Overview
            BunifuBackButton_Click(this, new EventArgs());
        }

        #endregion Buttons
    }
}
