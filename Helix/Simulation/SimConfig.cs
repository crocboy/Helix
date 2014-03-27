using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    /// <summary>
    /// A class that provides startup settings for a Helix simulation
    /// </summary>
    public class SimConfig
    {
        public int Days = 50000;
        public int RootCouples = 2;

        public override string ToString()
        {
            string total = Days.ToString() + " days, ";
            total += RootCouples.ToString() + " root couples";

            return total;
        }
    }
}
