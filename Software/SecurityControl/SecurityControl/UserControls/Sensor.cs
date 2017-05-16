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
        public int Id { get; private set; } = 0;
        public int Pin { get; private set; } = 0;
        public string CustomName { get; private set; } = "";
        public bool State { get; private set; } = false;
        public bool Type { get; private set; } = false;  // true = push-to-make, false = push-to-break

        /// <summary>
        /// Create new Sensor visual component
        /// </summary>
        /// <param name="pin">Id</param>
        /// <param name="pin">Pin</param>
        /// <param name="name">Custom name</param>
        /// <param name="state">Current state</param>
        /// <param name="type">Type of sensor (true = push-to-make, false = push-to-break)</param>
        public Sensor(int id, int pin, string name, bool state, bool type)
        {
            InitializeComponent();

            SetId(id);
            SetPin(pin);
            SetCustomName(name);
            SetState(state);
            SetType(type);
        }

        /// <summary>
        /// Change id
        /// </summary>
        /// <param name="newId">New id</param>
        public void SetId(int newId)
        {
            this.Id = newId;
        }

        /// <summary>
        /// Change pin
        /// </summary>
        /// <param name="newPin">New pin</param>
        public void SetPin(int newPin)
        {
            this.Pin = newPin;
        }

        /// <summary>
        /// Change custom name
        /// </summary>
        /// <param name="newCustomName">New custom name</param>
        public void SetCustomName(string newCustomName)
        {
            this.CustomName = newCustomName;
            labelSensorName.Text = newCustomName;
        }

        /// <summary>
        /// Change current state
        /// </summary>
        /// <param name="newState">New current state</param>
        public void SetState(bool newState)
        {
            this.State = newState;
            bunifuSensorState.Value = newState;
        }

        /// <summary>
        /// change type of sensor
        /// </summary>
        /// <param name="type">New type of sensor (true = push-to-make, false = push-to-break)</param>
        private void SetType(bool type)
        {
            this.Type = type;
            if (type) labelSensorType.Text = "Push to make type";
            else labelSensorType.Text = "Push to break type";
        }
    }
}
