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

        /* People are married through these lists! */
        public List<Man> maleBachelors = new List<Man>(0);
        public List<Woman> femaleBachelors = new List<Woman>(0);


        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="regions">Number of Regions</param>
        /// /// <param name="rootCouples">Number of root couples to create</param>
        /// <param name="db">Database to use for simulation</param>
        public World(int regions, int rootCouples, SQLiteDatabase db)
        {
            this.database = db;

            for (int i = 0; i < rootCouples; i++)
            {
                Man man = new Man(this, null, null)
                {
                    Name = Utility.GetRandomName(Person.GENDER_MALE)
                };

                Woman woman = new Woman(this, null, null)
                {
                    Name = Utility.GetRandomName(Person.GENDER_FEMALE)
                };

                Person.Marry(man, woman);

                AddPerson(man);
                AddPerson(woman);
            }
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
            this.database.Insert("people", person.GetDBData());
        }
    }
}
