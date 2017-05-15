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
    public partial class Sensor : UserControl
    {
        public int Pin { get; private set; } = 0;
        public string CustomName { get; private set; } = "";
        public bool State { get; private set; } = false;
        public bool Type { get; private set; } = false;  // true = push-to-make, false = push-to-break
        
        public Sensor(int pin, string name, bool state, bool type)
        {
            InitializeComponent();

            SetPin(pin);
            SetName(name);
            SetState(state);
            SetType(type);
        }

        public void SetPin(int newPin)
        {
            this.Pin = newPin;
        }

        public void SetName(string newName)
        {
            this.CustomName = newName;
            labelSensorName.Text = newName;
        }

        public void SetState(bool newState)
        {
            this.State = newState;
            bunifuSensorState.Value = newState;
        }

        private void SetType(bool type)
        {
            this.Type = type;
            if (type) labelSensorType.Text = "Push to make type";
            else labelSensorType.Text = "Push to break type";
        }
    }
}
