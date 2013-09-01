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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /* Browse button was pressed */
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                dbNameBox.Text = fileDialog.FileName;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            SimConfig config = new SimConfig()
            {
                DatabasePath = dbNameBox.Text
            };

            Simulation helix = new Simulation(config);
        }
    }
}
