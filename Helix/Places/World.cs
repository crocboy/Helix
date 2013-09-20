using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;

namespace Helix
{
    /// <summary>
    /// World represents all Regions and all people
    /// </summary>
    public class World  :Region
    {
        private int currentID = 1;

        private List<Region> childRegions = new List<Region>(0);

        public List<Person> peopleQueue = new List<Person>(0);

        /* People are married through these lists! */
        public List<Man> maleBachelors = new List<Man>(0);
        public List<Woman> femaleBachelors = new List<Woman>(0);


        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="regions">Number of Regions</param>
        /// /// <param name="rootCouples">Number of root couples to create</param>
        public World(int regions, int rootCouples)
        {

            for (int i = 0; i < rootCouples; i++)
            {
                Man man = new Man(this, null, null)
                {
                    Name = Utility.GetRandomName(Person.GENDER_MALE)
                };

                Woman woman = new Woman(this, null, null)
                {
                    Name = Utility.GetRandomName(Person.GENDER_FEMALE)
                };

                Person.Marry(man, woman);

                AddPerson(man);
                AddPerson(woman);
            }
        }


        /// <summary>
        /// Advance the time of the world
        /// </summary>
        /// <param name="steps">Number of time units to step</param>
        public void AdvanceTime(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                /* Add the people in the queue */
                People.AddRange(peopleQueue);
                peopleQueue.Clear();

                foreach (Person person in People)
                {
                    person.NextDay(); // Advance the life of each person
                }
            }
        }

        /// <summary>
        /// Get a new, unique ID number
        /// </summary>
        /// <returns>Unique ID</returns>
        public int GetNewID()
        {
            return currentID++;
        }

        /// <summary>
        /// Add a new Person to this World
        /// </summary>
        /// <param name="person">Person to be added</param>
        public void AddPerson(Person person)
        {
            this.peopleQueue.Add(person);
        }

        /// <summary>
        /// Save the family tree for this world.
        /// </summary>
        /// <param name="file">Filename</param>
        public void SaveFamilyFile(String file)
        {
            /* Intro stuff */
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode familyNode = doc.CreateElement("Family");

            /* Do attribute junk */
            XmlAttribute att1 = doc.CreateAttribute("xmlns:xsi");
            att1.Value = "http://www.w3.org/2001/XMLSchema-instance";
            familyNode.Attributes.Append(att1);

            XmlAttribute att2 = doc.CreateAttribute("xmlns:xsd");
            att2.Value = "http://www.w3.org/2001/XMLSchema";
            familyNode.Attributes.Append(att2);

            XmlAttribute att3 = doc.CreateAttribute("Current");
            att3.Value = "I1";
            familyNode.Attributes.Append(att3);

            XmlAttribute att4 = doc.CreateAttribute("CurrentName");
            att4.Value = "God";
            familyNode.Attributes.Append(att4);

            XmlAttribute att5 = doc.CreateAttribute("FileVersion");
            att5.Value = "1.0";
            familyNode.Attributes.Append(att5);

            XmlNode personListNode = doc.CreateElement("PeopleCollection");

            /** Add every person! */
            foreach (Person p in People)
            {
                XmlNode node = doc.CreateElement("Person");
                XmlAttribute id = doc.CreateAttribute("Id");
                id.Value = "I" + p.ID.ToString();
                node.Attributes.Append(id);

                XmlNode fnNode = doc.CreateElement("FirstName");
                fnNode.AppendChild(doc.CreateTextNode(p.GetFirstName()));
                XmlNode lnNode = doc.CreateElement("LastName");
                lnNode.AppendChild(doc.CreateTextNode(p.GetLastName()));
                XmlNode lifeNode = doc.CreateElement("IsLiving");
                lifeNode.AppendChild(doc.CreateTextNode(Convert.ToBoolean(p.LifeState).ToString()));

                node.AppendChild(fnNode);
                node.AppendChild(lnNode);
                node.AppendChild(lifeNode);

                personListNode.AppendChild(node);
            }
            

            //foreach

            familyNode.AppendChild(personListNode);
            doc.AppendChild(familyNode);

            doc.Save(file);
        }

        private void AddPerson(Person p, XmlDocument doc)
        {
            //
        }
    }
}
