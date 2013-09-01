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
        SQLiteDatabase database;

        public Simulation(SimConfig config)
        {
            this.database = new SQLiteDatabase(config.DatabasePath);
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("id", "0");
            data.Add("mom", "1");
            data.Add("dad", "2");
            data.Add("life_state", "1");

            this.database.Insert("people", data);

            DataTable table = this.database.GetDataTable("SELECT * FROM people;");
        }
    }


    /// <summary>
    /// A class that provides startup settings for a Helix simulation
    /// </summary>
    public class SimConfig
    {
        public String DatabasePath = "";
    }
}
