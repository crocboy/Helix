using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    /// <summary>
    /// World represents all Regions and all people
    /// </summary>
    public class World  :Region
    {
        private SQLiteDatabase database;
        private int currentID = 1;

        private List<Region> childRegions = new List<Region>(0);

        public List<Person> peopleQueue = new List<Person>(0);


        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="regions">Number of Regions</param>
        /// <param name="db">Database to use for simulation</param>
        public World(int regions, SQLiteDatabase db)
        {
            this.database = db;

            Man Adam = new Man(this, null, null)
            {
                Name = "Adam"
            };

            Woman Eve = new Woman(this, null, null)
            {
                Name = "Eve"
            };

            AddPerson(Adam);
            AddPerson(Eve);
        }


        /// <summary>
        /// Advance the time of the world
        /// </summary>
        /// <param name="steps">Number of time units to step</param>
        public void AdvanceTime(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                /* Add the people in the queue */
                People.AddRange(peopleQueue);
                peopleQueue.Clear();

                foreach (Person person in People)
                {
                    person.NextDay(); // Advance the life of each person
                }
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
            this.peopleQueue.Add(person);
            //this.database.Insert("people", person.GetDBData());
        }
    }
}
