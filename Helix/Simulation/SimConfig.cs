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
        public String DatabasePath = "";
        public int Days = 50000;
        public int RootCouples = 2;

        public override string ToString()
        {
            String total = "Database: " + DatabasePath + "\n";
            total += "Days: " + Days.ToString() + "\n";
            total += "Root Couples: " + RootCouples.ToString() + "\n";

            return total;
        }
    }
}
