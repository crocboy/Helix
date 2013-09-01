using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace Helix
{
    /// <summary>
    /// Manages the virtual world.  Provides a general interface into the component classes.
    /// </summary>
    public class Simulation
    {
        private SQLiteDatabase database;
        private World world;
        private int days;

        public Simulation(SimConfig config)
        {
            this.database = new SQLiteDatabase(config.DatabasePath);
            this.days = config.Days;

            /*Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("id", "0");
            data.Add("mom", "1");
            data.Add("dad", "2");
            data.Add("life_state", "1");

            this.database.Insert("people", data);

            DataTable table = this.database.GetDataTable("SELECT * FROM people;");*/
        }

        /// <summary>
        /// Start the simulation.
        /// </summary>
        public void Run()
        {
            this.database.ClearDB();

            world = new World(1, this.database);

            for (int i = 0; i < days; i++) // Step through each day
            {
                world.AdvanceTime(1);
            }
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
