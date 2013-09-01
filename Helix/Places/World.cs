using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    /// <summary>
    /// World represents all Regions and all people
    /// </summary>
    class World  :Region
    {
        private SQLiteDatabase database;
        private int currentID = 1;

        private List<Region> childRegions = new List<Region>(0);

        public List<Person> Alive = new List<Person>(0);
        public List<Person> Dead = new List<Person>(0);

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="regions">Number of Regions</param>
        /// <param name="db">Database to use for simulation</param>
        public World(int regions, SQLiteDatabase db)
        {
            this.database = db;

            this.People.Add(new Woman(GetNewID(), this));
            this.People.Add(new Woman(GetNewID(), this));
        }


        /// <summary>
        /// Advance the time of the world
        /// </summary>
        /// <param name="steps">Number of time units to step</param>
        public void AdvanceTime(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                //foreach (Region region in childRegions)
                //{
                    foreach (Person person in People)
                    {
                        person.NextDay(); // Advance the life of each person
                    }
                //}
            }
        }

        /// <summary>
        /// Get a new, unique ID number
        /// </summary>
        /// <returns>Unique ID</returns>
        public int GetNewID()
        {
            return currentID++;
        }

        /// <summary>
        /// Add a new Person to this World
        /// </summary>
        /// <param name="person">Person to be added</param>
        public void AddPerson(Person person)
        {
            //this.People.Add(person);
            this.Alive.Add(person);
            Insert(person);
        }


        /// <summary>
        /// Insert a person into the simulation database
        /// </summary>
        /// <param name="person"></param>
        private void Insert(Person person)
        {
            Dictionary<string, string> data = new Dictionary<string,string>();

            data.Add("id", Convert.ToString(person.ID));
            //data.Add("mom", Convert.ToString(person.ID));
            //data.Add("dad", Convert.ToString(person.ID));
            //data.Add("spouse", Convert.ToString(person.ID));
            data.Add("life_state", Convert.ToString(person.LifeState));
            data.Add("gender", Convert.ToString(person.Gender));

            database.Insert("people", data);
        }
    }
}
