using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    class Person
    {
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
        public Person Mom;
        public Person Dad;
        public Person Spouse;
        public List<Person> Children = new List<Person>();
        public World world;

        /* Internal instance variables */

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="id">Unique ID number for this person</param>
        /// <param name="w">Reference to the Person's world</param>
        public Person(int id, World w)
        {
            this.ID = id;
            this.world = w;

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
                this.world.Alive.Remove(this);
                this.world.Dead.Add(this);
            }
        }
    }
}
