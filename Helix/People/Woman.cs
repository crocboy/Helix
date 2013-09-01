using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    public class Woman : Person
    {
        public Man Spouse = null;


        public Woman(World w, Man dad, Woman mom) : base(w, dad, mom)
        {
            Gender = GENDER_FEMALE;
        }

        override public void NextDay()
        {
            base.NextDay(); // Call super method

            /* Spawn a child every once in a while */
            if(Age % 10000 == 0)
            {
                Woman child = new Woman(world, this.Spouse, this);

                this.world.AddPerson(child);
            }
        }

        public override Dictionary<string, string> GetDBData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            /* Check for valid values in EVERY field */
            data.Add("id", Convert.ToString(this.ID));

            if (Mom == null) // Check Mom
                data.Add("mom", "-1");
            else
                data.Add("mom", Convert.ToString(this.Mom.ID));

            if(Dad == null) // Check Dad
                data.Add("dad", "-1");
            else
                data.Add("dad", Convert.ToString(this.Dad.ID));

            if(Spouse == null) // Check Spouse
                data.Add("spouse", "-1");
            else
                data.Add("spouse", Convert.ToString(this.Spouse.ID));

            data.Add("life_state", Convert.ToString(this.LifeState));
            data.Add("gender", Convert.ToString(this.Gender));

            return data;
        }
    }
}
