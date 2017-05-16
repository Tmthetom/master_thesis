using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SecurityControl.Arduino
{
    public class Operations
    {
        #region Initialisation

        Connection myConnection;

        /// <summary>
        /// Initialise operations with connection
        /// </summary>
        /// <param name="connection">Arduino connection</param>
        public Operations(Connection connection)
        {
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
            Regex regex = new Regex(@"\(Id = ([0-9]+),Pin = ([0-9]+),Name = ([a-zA-Z ]+),State = ([0-1]),Type = ([0-1])\)");

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

                    sensors.Add(new UserControls.Sensor(this, id, pin, name, state, type));
                }
            }

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
            Regex regex = new Regex(@"\(Id = ([0-9]+),Pin = ([0-9]+),Name = ([a-zA-Z ]+),State = ([0-1])\)");

            // Parse
            foreach (Match match in regex.Matches(inString))
            {
                if (match.Success)
                {
                    int id = Int32.Parse(match.Groups[1].Value);
                    int pin = Int32.Parse(match.Groups[2].Value);
                    String name = match.Groups[3].Value;
                    bool state = (Int32.Parse(match.Groups[4].Value) == 0) ? false : true;

                    switches.Add(new UserControls.Switch(this, id, pin, name, state));
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set pin of switch id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="pin">new pin</param>
        public void SetSensorPin(int id, int pin)
        {
            throw new NotImplementedException();
        }

        #endregion Sensor

        #region Switch

        /// <summary>
        /// Set state of switch id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="state">New state</param>
        public void SetSwitchState(int id, bool state)
        {
            int intState = (state == false) ? 0 : 1;
            myConnection.Send("SetSwitchState(" + id + "," + intState);
        }

        /// <summary>
        /// Set name of switch id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">New name</param>
        public void SetSwitchName(int id, String name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set pin of switch id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="pin">New pin</param>
        public void SetSwitchPin(int id, int pin)
        {
            throw new NotImplementedException();
        }

        #endregion Switch

        #endregion Setters
    }
}
