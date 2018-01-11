using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace SecurityControl.UserControls
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
            InitializeValues();
        }

        public void InitializeValues()
        {
            labelAbout.Text = "This software was created by Tomáš Moravec as part of his master project and its property of Technical University of Liberec.";

            labelContact.Text = "Contact on Author:";
            labelContactNumber.Text = "+420 776 006 865";
            labelContactEmail.Text = "moravec-tomas@seznam.cz";

            labelVersion.Text = "Current version:";
            labelVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
