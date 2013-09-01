using System;
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

            data.Add("life_state", Convert.ToString(this.LifeState));
            data.Add("gender", Convert.ToString(this.Gender));

            return data;
        }
    }
}
