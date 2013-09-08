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

        /// <summary>
        /// HAVE A CHILLEN
        /// </summary>
        public void PopOneOut()
        {
            //if (Spouse != null) // Only have one if we're married :)
            //{
                int gender = Utility.GetRandomGender();

                if (gender == Person.GENDER_MALE) // Add a boy
                {
                    Man child = new Man(this.world, this.Spouse, this)
                    {
                        Name = Utility.GetRandomName(Person.GENDER_MALE, this.GetLastName())
                    };

                    this.Children.Add(child);
                    this.world.AddPerson(child);
                }
                else  // Add a girl
                {
                    Woman child = new Woman(this.world, this.Spouse, this)
                    {
                        Name = Utility.GetRandomName(Person.GENDER_FEMALE, this.GetLastName())
                    };

                    this.Children.Add(child);
                    this.world.AddPerson(child);
                }
            //}
        }

        override public void NextDay()
        {
            base.NextDay(); // Call super method

            /* Put these babes in the market */
            if (Age > Metrics.BACHELOR_START_AGE)
                world.femaleBachelors.Add(this);
            if (Age > Metrics.BACHELOR_END_AGE)
                world.femaleBachelors.Remove(this);

            /* Spawn a child every once in a while */
            if(Age % 10000 == 0)
            {
                PopOneOut();
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

            if (Name != null && Name != "") // Add name
                data.Add("name", Name);

            data.Add("life_state", Convert.ToString(this.LifeState));
            data.Add("gender", Convert.ToString(this.Gender));

            return data;
        }
    }
}
