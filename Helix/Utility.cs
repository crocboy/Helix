using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helix
{
    class Utility
    {
        /// <summary>
        /// Return a new radndom number based on the given seed
        /// </summary>
        /// <param name="limit">Inclusive limit for random number</param>
        /// <param name="seed">Seed for random number generator</param>
        /// <returns>Random number using the specified seed from 0 to limit (inclusive)</returns>
        public static int GetRandom(int seed, int limit)
        {
            Random random = new Random(seed);
            return random.Next(limit + 1);
        }


        /// <summary>
        /// Get a random number from 0 to limit, inclusive
        /// </summary>
        /// <param name="limit">Inclusive limit for random number</param>
        /// <returns></returns>
        public static int GetRandom(int limit)
        {
            Random random = new Random();
            return random.Next(limit + 1);
        }

        /// <summary>
        /// Get a random gender based on the metrics defined in the Metrics class
        /// </summary>
        /// <returns>Random gender, either Person.GENDER_FEMALE or Person.GENDER_MALE</returns>
        public static int GetRandomGender()
        {
            int random = GetRandom(100);

            if (random < (Metrics.FEMALE_RATIO * 100)) // It's a GIRL!
                return Person.GENDER_FEMALE;
            else
                return Person.GENDER_MALE; // It's a BOY!
        }
    }
}
