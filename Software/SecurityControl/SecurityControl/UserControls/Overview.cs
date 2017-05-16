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
    public partial class Overview : UserControl
    {
        Arduino.Connection myConnection;
        Arduino.Operations myOperations;
        int currentTop = 25;
        int indentLeft = 35;

        /// <summary>
        /// Initialise overview with connection
        /// </summary>
        /// <param name="connection">Arduino connection</param>
        public Overview(Arduino.Connection connection)
        {
            InitializeComponent();
            this.myConnection = connection;
            myOperations = new Arduino.Operations(myConnection);
            InitialiseComponents();
        }

        /// <summary>
        /// Initialise components
        /// </summary>
        public void InitialiseComponents()
        {
            AddSensors(myOperations.GetAllSensors());
            AddSwitches(myOperations.GetAllSwitches());
        }

        /// <summary>
        /// Add switches into panel
        /// </summary>
        /// <param name="switches">List of switches</param>
        public void AddSwitches(List<UserControls.Switch> switches)
        {
            foreach (UserControls.Switch mySwitch in switches)
            {
                mySwitch.Top = currentTop;
                mySwitch.Left = indentLeft;
                this.Controls.Add(mySwitch);
                currentTop += mySwitch.Height;
            }
        }

        /// <summary>
        /// Add sensors into panel
        /// </summary>
        /// <param name="sensors">List of panels</param>
        public void AddSensors(List<UserControls.Sensor> sensors)
        {
            foreach (UserControls.Sensor mySensor in sensors)
            {
                mySensor.Top = currentTop;
                mySensor.Left = indentLeft;
                this.Controls.Add(mySensor);
                currentTop += mySensor.Height;
            }
        }
    }
}
