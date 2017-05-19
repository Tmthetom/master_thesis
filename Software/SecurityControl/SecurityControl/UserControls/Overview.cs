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
        #region Initialisation

        FormMain myParent;
        Arduino.Connection myConnection;
        Arduino.Operations myOperations;
        int currentTop = 25;
        int indentLeft = 35;

        /// <summary>
        /// Initialise overview with connection
        /// </summary>
        /// <param name="connection">Arduino connection</param>
        /// <param name="parent">Parent of this form</param>
        public Overview(FormMain parent, Arduino.Connection connection)
        {
            InitializeComponent();
            myParent = parent;
            this.myConnection = connection;
            myOperations = new Arduino.Operations(myParent, myConnection);
        }

        /// <summary>
        /// Initialise components
        /// </summary>
        public void InitialiseComponentsFromArduino()
        {
            try
            {
                List<UserControls.Sensor> sensors = myOperations.GetAllSensors();
                List<UserControls.Switch> switches = myOperations.GetAllSwitches();

                this.Controls.Clear();
                currentTop = 25;

                if (sensors.Count == 0 && switches.Count == 0)
                {
                    AddEmptyWarning();
                }
                else
                {
                    AddSensors(sensors);
                    AddSwitches(switches);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Add switches into panel
        /// </summary>
        /// <param name="switches">List of switches</param>
        private void AddSwitches(List<UserControls.Switch> switches)
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
        private void AddSensors(List<UserControls.Sensor> sensors)
        {
            foreach (UserControls.Sensor mySensor in sensors)
            {
                mySensor.Top = currentTop;
                mySensor.Left = indentLeft;
                this.Controls.Add(mySensor);
                currentTop += mySensor.Height;
            }
        }

        /// <summary>
        /// Add label with empty Arduino warning
        /// </summary>
        private void AddEmptyWarning()
        {
            UserControls.EmtyArduino emptyArduino = new UserControls.EmtyArduino()
            {
                Top = currentTop,
                Left = indentLeft
            };
            this.Controls.Add(emptyArduino);
            currentTop += emptyArduino.Height;
        }

        /// <summary>
        /// When program not connected
        /// </summary>
        public void NotConnected()
        {
            this.Controls.Clear();
            NotConnected labelNotConneted = new NotConnected();
            this.Controls.Add(labelNotConneted);
            labelNotConneted.Dock = DockStyle.Fill;
            labelNotConneted.Show();
        }

        /// <summary>
        /// When program connected
        /// </summary>
        public void Connected()
        {
            ;
        }

        #endregion Initialisation
    }
}
