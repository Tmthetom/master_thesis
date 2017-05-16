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
        FormMain myParent;
        Arduino.Operations myOperations;
        public int Id { get; private set; } = 0;
        public int Pin { get; private set; } = 0;
        public string CustomName { get; private set; }  = "";
        public bool State { get; private set; } = false;

        /// <summary>
        /// Create new Switch visual component
        /// </summary>
        /// <param name="parent">Main form</param>
        /// <param name="operations">Operations for Arduino</param>
        /// <param name="pin">Id</param>
        /// <param name="pin">Pin</param>
        /// <param name="name">Custom name</param>
        /// <param name="state">Current state</param>
        public Switch(FormMain parent, Arduino.Operations operations, int id, int pin, string name, bool state)
        {
            InitializeComponent();

            myParent = parent;
            myOperations = operations;
            SetId(id);
            SetPin(pin);
            SetCustomName(name);
            SetState(state);
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
            labelSwitchName.Text = newCustomName;
        }

        /// <summary>
        /// Change current state
        /// </summary>
        /// <param name="newState">New current state</param>
        public void SetState(bool newState)
        {
            this.State = newState;
            bunifuSwitchState.Value = newState;
        }

        /// <summary>
        /// When user want to change switch state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuSwitchState_OnValueChange(object sender, EventArgs e)
        {
            myOperations.SetSwitchState(Id, bunifuSwitchState.Value);
        }

        /// <summary>
        /// Show sensor settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxSettings_Click(object sender, EventArgs e)
        {
            SwitchSettings switchSettings = new SwitchSettings(myParent);
            myParent.panelBody.Controls.Clear();
            myParent.panelBody.Controls.Add(switchSettings);
            switchSettings.Dock = DockStyle.Fill;
            switchSettings.Show();
        }
    }
}
