using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SQLite;
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

        private void startButton_Click(object sender, EventArgs args)
        {
            try
            {
                SimConfig config = new SimConfig()
                {
                    DatabasePath = dbNameBox.Text,
                    Days = Convert.ToInt32(daysBox.Text)
                };

                Simulation helix = new Simulation(config);

                logWindow.AppendText("Simulation starting...\n");

                helix.Run();// Run it!

                logWindow.AppendText("Simulation completed!\n");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error starting simulation: " + e.ToString(), "Simulation Exception");
            }
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            logWindow.Clear();
        }
    }
}
