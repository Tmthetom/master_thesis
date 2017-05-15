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
        int currentTop = 25;
        int indentLeft = 35;

        public Overview()
        {
            InitializeComponent();
        }

        public void AddSwitch(int pin, string name, bool state)
        {
            Switch newSwitch = new Switch(pin, name, state)
            {
                Top = currentTop,
                Left = indentLeft
            };
            this.Controls.Add(newSwitch);

            currentTop += newSwitch.Height;
        }

        public void AddSensor(int pin, string name, bool state, bool type)
        {
            Sensor newSwitch = new Sensor(pin, name, state, type)
            {
                Top = currentTop,
                Left = indentLeft
            };
            this.Controls.Add(newSwitch);

            currentTop += newSwitch.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSwitch(0, "Testing switch", true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSensor(0, "Testing sensor", true, true);
        }
    }
}
