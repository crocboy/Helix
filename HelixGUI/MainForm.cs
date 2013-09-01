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
        private Simulation helix;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            helix = new Simulation();
            helix.ProgressUpdated += OnProgressUpdated;
            helix.SimulationComplete += SimulationComplete;
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
                if (startButton.Text == "Start") // Start the simulation
                {
                    SimConfig config = new SimConfig()
                    {
                        DatabasePath = dbNameBox.Text,
                        Days = Convert.ToInt32(daysBox.Text)
                    };

                    logWindow.AppendText("Simulation starting...\n");
                    helix.Start(config);// Run it!

                    startButton.Text = "Stop";
                }
                else if (startButton.Text == "Stop") // Stop the simulation
                {
                    if (helix != null)
                    {
                        helix.Stop();
                        startButton.Text = "Start";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error starting simulation: " + e.ToString(), "Simulation Exception");
            }
        }


        /* Called when simulation progress is updated */
        private void OnProgressUpdated(int progress)
        {
            this.Invoke( (MethodInvoker) delegate
            {
                progressBar.Value = progress; // runs on UI thread
            });
        }

        /* Called when Simulation is complete! */
        private void SimulationComplete(World world)
        {
            this.Invoke((MethodInvoker)delegate
            {
                startButton.Text = "Start";
                logWindow.AppendText("Simulation complete!\n");
                progressBar.Value = 0;
            });
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            logWindow.Clear();
        }
    }
}
