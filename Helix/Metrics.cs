using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    /// <summary>
    /// Contains static metrics for the Simulation
    /// </summary>
    class Metrics
    {

        public const double FEMALE_RATIO = .51;

        public const double MALE_RATIO = 1 - FEMALE_RATIO; // Based on the above metric

        /* Defines the ages that people can get married */
        public const int BACHELOR_START_AGE = 2300;
        public const int BACHELOR_END_AGE   = 10950;
    }
}
