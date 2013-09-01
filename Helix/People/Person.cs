using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    public class Person
    {
        /* Constants used for constructing */
        public const int LIVE = 1;
        public const int DEAD = 0;
        public const int GENDER_MALE   = 0;
        public const int GENDER_FEMALE = 1;
        public const int MAX_LIFE  = 29200;


        /* Public instance variables */
        public int ID = -1;
        public int Gender = GENDER_MALE;
        public int Age = 0;
        public int LifeState = LIVE;
        public String Name = "";
        public Person Mom = null;
        public Person Dad = null;
        public List<Person> Children = new List<Person>();
        public World world;

        /* Internal instance variables */

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="w">World to be inserted into</param>
        /// <param name="dad">Father of this person</param>
        /// <param name="mom">Mother of this person</param>
        public Person(World w, Man dad, Woman mom)
        {
            this.ID = w.GetNewID();
            this.world = w;

            this.Dad = dad;
            this.Mom = mom;

            this.world.AddPerson(this);
        }

        /// <summary>
        /// Advance life by one day
        /// </summary>
        virtual public void NextDay()
        {
            Age++;

            if (Age >= MAX_LIFE) // We're dead :(
            {
                LifeState = DEAD;
            }
        }

        /// <summary>
        /// Get a Dictionary of data suitable for inserting into the database
        /// </summary>
        /// <returns>Dictionary for inserting into the database</returns>
        public virtual Dictionary<string, string> GetDBData()
        {
            throw new NotImplementedException("Person.GetDBData() not implemented!");
        }
    }
}
