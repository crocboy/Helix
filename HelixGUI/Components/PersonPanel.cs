using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelixGUI.Components
{
    /// <summary>
    /// PersonPanel is a small Panel that displays relevant information about a Person
    /// </summary>
    public partial class PersonPanel : UserControl
    {
        public PersonPanel()
        {
            InitializeComponent();
        }

        private void PersonPanel_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Load a Person
        /// </summary>
        /// <param name="person">Person to load</param>
        public void LoadPErson(PersonPanel person)
        {
            //
        }
    }
}
