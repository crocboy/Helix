using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    class Woman : Person
    {
        public Woman(int id, World w) : base(id, w)
        {
            Gender = GENDER_FEMALE;
        }

        override public void NextDay()
        {
            base.NextDay(); // Call super method

            /* Spawn a child every once in a while */
            if(Age % 10000 == 0)
            {
                Person child = new Person(world.GetNewID(), world)
                {
                    Mom = this
                };

                this.world.AddPerson(child);
            }
        }
    }
}
