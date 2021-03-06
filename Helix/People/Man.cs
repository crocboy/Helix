﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    public class Man : Person
    {
        public Woman Spouse = null;

        public Man(World w, Man dad, Woman mom) : base(w, dad, mom)
        {
            //
        }

        public override void NextDay()
        {
            base.NextDay();

            /* Bachelor check */
            if (Age > Metrics.BACHELOR_START_AGE) // We're eligable, get married!
            {
                if (world.femaleBachelors.Count > 0 && this.Spouse == null)
                {
                    Person.Marry(this, Utility.GetRandom<Woman>(world.femaleBachelors));
                    this.world.maleBachelors.Remove(this);
                    this.world.femaleBachelors.Remove(this.Spouse);
                }
            }
        }

        public override Dictionary<string, string> GetDBData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            /* Check for valid values in EVERY field */
            data.Add("id", Convert.ToString(this.ID));

            if (Mom == null)
                data.Add("mom", "-1");
            else
                data.Add("mom", Convert.ToString(this.Mom.ID));

            if (Dad == null)
                data.Add("dad", "-1");
            else
                data.Add("dad", Convert.ToString(this.Dad.ID));

            if (Spouse == null)
                data.Add("spouse", "-1");
            else
                data.Add("spouse", Convert.ToString(this.Spouse.ID));
            if (Name != null && Name != "") // Add name
                data.Add("name", Name);

            data.Add("age", Age.ToString());
            data.Add("life_state", this.LifeState.ToString());
            data.Add("gender", this.Gender.ToString());

            return data;
        }
    }
}
