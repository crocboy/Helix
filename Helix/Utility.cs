using System;
using System.IO;
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
        /// Return a random item from a generic List
        /// </summary>
        /// <typeparam name="T">Type of the list</typeparam>
        /// <param name="list">List to retrieve random item from</param>
        /// <returns>A random item from List</returns>
        public static T GetRandom<T>(List<T> list)
        {
            int random = GetRandom(list.Count - 1);
            return list[random];
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

        /// <summary>
        /// Return a random name
        /// </summary>
        /// <param name="gender">Desired gender</param>
        /// <returns>Random name, in the form "FIRST LAST"</returns>
        public static String GetRandomName(int gender)
        {
            List<String> firstNames = GetFile("Files\\MALE_NAMES.txt");
            List<String> surnames = GetFile("Files\\SURNAMES.txt");

            if(gender == Person.GENDER_FEMALE)
                firstNames = GetFile("Files\\FEMALE_NAMES.txt");

            int first = GetRandom(firstNames.Count - 1);
            int last = GetRandom(surnames.Count - 1);

            return firstNames[first] + " " + surnames[last]; // Return the concatenated name
        }

        /// <summary>
        /// Return a random name
        /// </summary>
        /// <param name="gender">Desired gender</param>
        /// <param name="surname">Desired surname</param>
        /// <returns>Random name, in the form "FIRST LAST"</returns>
        public static String GetRandomName(int gender, String surname)
        {
            return GetRandomName(gender).Split(' ')[0].Trim() + " " + surname.Trim();
        }


        /// <summary>
        /// Read a file into a list of lines
        /// </summary>
        /// <param name="file">Name of file</param>
        /// <returns>List of all lines in the text file</returns>
        public static List<String> GetFile(String file)
        {
            StreamReader reader = new StreamReader(file);

            List<String> lines = new List<string>(0);
            String line = "";

            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }
    }
}
