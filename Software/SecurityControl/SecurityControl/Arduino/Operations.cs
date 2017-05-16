using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecurityControl.Arduino
{
    class Operations
    {
        #region Getters

        public List<UserControls.Sensor> GetAllSensors(Connection myConnection)
        {
            // Sensors((Id = 0,Pin = 8,Name = Main Door Sensor,State = 0))
            List<UserControls.Sensor> sensors = new List<UserControls.Sensor>();

            // Get
            myConnection.Send("GetAllSensors");
            String inString =  myConnection.ReadLine();
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

                    sensors.Add(new UserControls.Sensor(id, pin, name, state, type));
                }
            }

            return sensors;
        }

        public List<UserControls.Switch> GetAllSwitches(Connection myConnection)
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

                    switches.Add(new UserControls.Switch(id, pin, name, state));
                }
            }

            return switches;
        }
                
        #endregion Getters
    }
}
