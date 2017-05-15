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
    public partial class Switch : UserControl
    {
        public int Pin { get; private set; } = 0;
        public string CustomName { get; private set; }  = "";
        public bool State { get; private set; } = false;

        public Switch(int pin, string name, bool state)
        {
            InitializeComponent();

            SetPin(pin);
            SetName(name);
            SetState(state);
        }

        public void SetPin(int newPin)
        {
            this.Pin = newPin;
        }

        public void SetName(string newName)
        {
            this.CustomName = newName;
            labelSwitchName.Text = newName;
        }

        public void SetState(bool newState)
        {
            this.State = newState;
            bunifuSwitchState.Value = newState;
        }
    }
}
