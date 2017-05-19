using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SecurityControl.Arduino
{
    public class Operations
    {
        #region Initialisation

        FormMain myParent;
        Connection myConnection;

        /// <summary>
        /// Initialise operations with connection
        /// </summary>
        /// <param name="connection">Arduino connection</param>
        public Operations(FormMain parent, Connection connection)
        {
            this.myParent = parent;
            this.myConnection = connection;
        }

        #endregion Initialisation

        #region Getters

        /// <summary>
        /// Get all sensors
        /// </summary>
        /// <returns>List of sensors</returns>
        public List<UserControls.Sensor> GetAllSensors()
        {
            // Sensors((Id = 0,Pin = 8,Name = Main Door Sensor,State = 0))
            List<UserControls.Sensor> sensors = new List<UserControls.Sensor>();

            // Get
            myConnection.Send("GetAllSensors");
            String inString = myConnection.ReadLine();
            Regex regex = new Regex(@"\(Id = ([0-9]+),Pin = ([0-9]+),Name = ([a-zA-Z0-9 ]+),State = ([0-1]),Type = ([0-1])\)");

            // Parse
            foreach (Match match in regex.Matches(inString))
            {
                if (match.Success)
                {
                    int id = Int32.Parse(match.Groups[1].Value);
                    int pin = Int32.Parse(match.Groups[2].Value);
                    String name = match.Groups[3].Value;
                    bool state = (Int32.Parse(match.Groups[4].Value) == 0) ? false : true;
                    bool type = (Int32.Parse(match.Groups[5].Value) == 0) ? false : true;

                    sensors.Add(new UserControls.Sensor(myParent, this, id, pin, name, state, type));
                }
            }

            MessageBox.Show(inString);

            return sensors;
        }

        /// <summary>
        /// Get all switches
        /// </summary>
        /// <returns>List of switches</returns>
        public List<UserControls.Switch> GetAllSwitches()
        {
            // Switches((Id = 0,Pin = 3,Name = Right Led Switch,State = 0)(Id = 1,Pin = 4,Name = Left Led Switch,State = 0))
            List<UserControls.Switch> switches = new List<UserControls.Switch>();

            // Get
            myConnection.Send("GetAllSwitches");
            String inString = myConnection.ReadLine();
            Regex regex = new Regex(@"\(Id = ([0-9]+),Pin = ([0-9]+),Name = ([a-zA-Z0-9 ]+),State = ([0-1])\)");

            // Parse
            foreach (Match match in regex.Matches(inString))
            {
                if (match.Success)
                {
                    int id = Int32.Parse(match.Groups[1].Value);
                    int pin = Int32.Parse(match.Groups[2].Value);
                    String name = match.Groups[3].Value;
                    bool state = (Int32.Parse(match.Groups[4].Value) == 0) ? false : true;

                    switches.Add(new UserControls.Switch(myParent, this, id, pin, name, state));
                }
            }

            return switches;
        }

        #endregion Getters

        #region Setters

        #region Sensor

        /// <summary>
        /// Set name of sensor id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">New name</param>
        public void SetSensorName(int id, String name)
        {
            if (id > -1 && id < 100)
                myConnection.Send("SetSensorName(" + id + "," + name + ")");
        }

        /// <summary>
        /// Set pin of sensor id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="pin">new pin</param>
        public void SetSensorPin(int id, int pin)
        {
            if (id > -1 && id < 100 && pin > 0 && pin < 100)
                myConnection.Send("SetSensorPin(" + id + "," + pin + ")");
        }

        /// <summary>
        /// Set type of sensor id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="type">true = push-to-make, false = push-to-break</param>
        public void SetSensorType(int id, bool type)
        {
            if (id > -1 && id < 100)
            {
                int intType = (type == false) ? 0 : 1;
                myConnection.Send("SetSensorType(" + id + "," + intType + ")");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pin">Pin</param>
        /// <param name="name">Custom name</param>
        /// <param name="type">true = push-to-make, false = push-to-break</param>
        public void AddSensor(int pin, String name, bool type)
        {
            if (pin > 0 && pin < 100)
            {
                int intType = (type == true) ? 1 : 0;  // 1 = HIGH, 0 = LOW
                myConnection.Send("AddSensor(" + pin + "," + name + "," + intType + ")");
            }
        }

        /// <summary>
        /// Delete sensor
        /// </summary>
        /// <param name="id">Id</param>
        public void DeleteSensor(int id)
        {
            if (id > -1 && id < 100)
                myConnection.Send("DeleteSensor(" + id + ")");
        }

        #endregion Sensor

        #region Switch

        /// <summary>
        /// Set name of switch id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">New name</param>
        public void SetSwitchName(int id, String name)
        {
            if (id > -1 && id < 100)
                myConnection.Send("SetSwitchName(" + id + "," + name + ")");
        }

        /// <summary>
        /// Set state of switch id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="state">New state</param>
        public void SetSwitchState(int id, bool state)
        {
            if (id > -1 && id < 100)
            {
                int intState = (state == true) ? 1 : 0;
                myConnection.Send("SetSwitchState(" + id + "," + intState + ")");
            }
        }

        /// <summary>
        /// Set pin of switch id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="pin">New pin</param>
        public void SetSwitchPin(int id, int pin)
        {
            if (id > -1 && id < 100 && pin > 0 && pin < 100)
                myConnection.Send("SetSwitchPin(" + id + "," + pin + ")");
        }

        /// <summary>
        /// Add switch
        /// </summary>
        /// <param name="pin">Pin</param>
        /// <param name="name">Custom name</param>
        /// <param name="state">true = High, false = Low</param>
        public void AddSwitch(int pin, String name, bool state)
        {
            if (pin > 0 && pin < 100)
            {
                int intState = (state == true) ? 1 : 0;  // 1 = HIGH, 0 = LOW
                myConnection.Send("AddSwitch(" + pin + "," + name + "," + state + ")");
            }
        }

        /// <summary>
        /// Delete switch
        /// </summary>
        /// <param name="id">Id</param>
        public void DeleteSwitch(int id)
        {
            if (id > -1 && id < 100)
                myConnection.Send("DeleteSwitch(" + id + ")");
        }

        #endregion Switch

        #endregion Setters

        #region Reader

        /// <summary>
        /// Read
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            return myConnection.ReadLine();
        }

        #endregion Reader
    }
}
