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
        private SimConfig simConfig = new SimConfig();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //
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
                    StartSimulation();
                    startButton.Text = "Stop";
                }
                else if (startButton.Text == "Stop") // Stop the simulation
                {
                    if (helix != null)
                    {
                        StopSimulation();
                        startButton.Text = "Start";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error starting simulation: " + e.ToString(), "Simulation Exception");
            }
        }


        /// <summary>
        /// Starts the Simulation using the GUI-defined parameters.
        /// </summary>
        public void StartSimulation()
        {
            helix = new Simulation();
            helix.ProgressUpdated += OnProgressUpdated;
            helix.SimulationComplete += SimulationComplete;

            logWindow.AppendText("Simulation starting: " + simConfig.ToString() + " days\n");
            helix.Start(simConfig);// Run it!
        }

        /// <summary>
        /// Stop the Simulation.
        /// </summary>
        public void StopSimulation()
        {
            helix.Stop();
        }

        /* Called when the SimConfig changes */
        private void OnSimConfigChanged(SimConfig newConfig)
        {
            this.simConfig = newConfig;
        }


        /* Called when simulation progress is updated */
        private void OnProgressUpdated(int progress)
        {
            this.Invoke((MethodInvoker)delegate
            {
                progressBar.Value = progress; // runs on UI thread
            });
        }

        /* Called when Simulation is complete! */
        private void SimulationComplete(World world, long time)
        {
            this.Invoke((MethodInvoker)delegate // Runs this on UI thread
            {
                world.SaveFamilyFile("tree.family");

                logWindow.AppendText("Done adding!\n");
                startButton.Text = "Start";
                logWindow.AppendText("Simulation completed in " + time.ToString() + " ms\n");
                logWindow.AppendText("World had " + world.People.Count.ToString() + " people\n");
                progressBar.Value = 0;
            });
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            logWindow.Clear();
        }

        /* Called when File -> Close is pressed */
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editSim_Click(object sender, EventArgs e)
        {
            SimEdit simEdit = new SimEdit();
            simEdit.OnConfigChanged += OnSimConfigChanged;
            simEdit.Show();
        }
    }
}
