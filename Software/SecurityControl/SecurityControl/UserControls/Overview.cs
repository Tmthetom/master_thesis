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
        Arduino.Connection myConnection = null;
        Arduino.Operations myOperations = new Arduino.Operations();
        int currentTop = 25;
        int indentLeft = 35;

        public Overview(Arduino.Connection connection)
        {
            InitializeComponent();
            this.myConnection = connection;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            AddSensors(myOperations.GetAllSensors(myConnection));
            AddSwitches(myOperations.GetAllSwitches(myConnection));
        }
    }
}
