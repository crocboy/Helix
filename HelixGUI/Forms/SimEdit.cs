using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helix;

namespace HelixGUI
{
    /// <summary>
    /// SimEdit is a form that allows the editing of a SimConfig object
    /// </summary>
    public partial class SimEdit : Form
    {
        public delegate void OnSimConfigChanged(SimConfig newConfig);
        public event OnSimConfigChanged OnConfigChanged;


        public SimEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Build a SimConfig object from the GUI
        /// </summary>
        /// <returns>SimConfig as represented by the GUI elements</returns>
        private SimConfig GetSimConfig()
        {
            try
            {
                SimConfig config = new SimConfig()
                {
                    Days = Convert.ToInt32(daysBox.Text),
                    RootCouples = Convert.ToInt32(couplesBox.Text)
                };

                return config;
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not create SimConfig: " + e.ToString());
                return null;
            }
        }

        private void SimEdit_Load(object sender, EventArgs e)
        {

        }

        /* Cancel was pressed, close the window */
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /* OK was pressed, raise the event */
        private void okButton_Click(object sender, EventArgs e)
        {
            SimConfig config = GetSimConfig();

            if (config != null)
            {
                this.OnConfigChanged(GetSimConfig());
                this.Dispose();
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            SimConfig config = GetSimConfig();

            if (config != null)
            {
                this.OnConfigChanged(GetSimConfig());
            }
        }
    }
}
