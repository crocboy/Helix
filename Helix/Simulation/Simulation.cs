using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using System.Data.SQLite;

namespace Helix
{
    /// <summary>
    /// Manages the virtual world.  Provides a general interface into the component classes.
    /// </summary>
    public class Simulation
    {
        /* Callback methods */
        public delegate void OnProgressUpdated(int progress);
        public delegate void SimulationCompleted(World world);
        
        /* Event objects */
        public event OnProgressUpdated ProgressUpdated;
        public event SimulationCompleted SimulationComplete;

        private Thread simThread;
        private SQLiteDatabase database;
        private World world;
        private int days;
        private bool stopSimThread = false;

        /// <summary>
        /// Public constructor (Empty)
        /// </summary>
        public Simulation()
        {
            //
        }

        /// <summary>
        /// Start the simulation.
        /// </summary>
        public void Start(SimConfig config)
        {
            this.days = config.Days;
            this.database = new SQLiteDatabase(config.DatabasePath);
            this.database.ClearDB();

            simThread = new Thread(RunSimulation)
            {
                Name = "Simulation Thread"
            };

            simThread.Start();
        }

        private void RunSimulation()
        {
            while (!stopSimThread)
            {
                world = new World(1, this.database);

                int stepSize = Convert.ToInt32(Convert.ToDouble(days) / 100f); // 1/100th of the simulation length
                int progress = 0; // Progress, in percent

                for (int i = 0; i < days; i++) // Step through each day
                {
                    world.AdvanceTime(1);

                    if (i % stepSize == 0)
                        ProgressUpdated(progress++);
                }

                SimulationComplete(world);
                stopSimThread = true; // Stop the current Thread
            }
        }

        /// <summary>
        /// Stop the Simulation
        /// </summary>
        public void Stop()
        {
            stopSimThread = true;
            SimulationComplete(world);
        }
    }


    /// <summary>
    /// A class that provides startup settings for a Helix simulation
    /// </summary>
    public class SimConfig
    {
        public String DatabasePath = "";
        public int Days = 0;
    }
}
