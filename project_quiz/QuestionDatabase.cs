using System;
using System.Collections;
using System.Collections.Specialized;

namespace project_quiz
{
    public class QuestionDatabase
    {
        OrderedDictionary myOrderedDictionary = new OrderedDictionary()
            {
                {"Sverige", "Stockholm"},
                {"Danmark", "Köpenhamn"},
                {"Norge", "Oslo"},
                { "Finland", "Helsingfors"}
            };

        ICollection keyCollection;
        ICollection valueCollection;

        public QuestionDatabase()
        {
            keyCollection = myOrderedDictionary.Keys;
            valueCollection = myOrderedDictionary.Values;

            // Display the contents using the key and value collections
            DisplayContents(keyCollection, valueCollection, myOrderedDictionary.Count);
        }


        public void DisplayContents(
            ICollection keyCollection, ICollection valueCollection, int dictionarySize)
        {
            String[] myKeys = new String[dictionarySize];
            String[] myValues = new String[dictionarySize];
            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            Random rnd = new Random();
            int fråga = rnd.Next(4);

            // Displays the contents of the OrderedDictionary
            Console.WriteLine(myKeys[fråga] + myValues[fråga]);
        }
    }
}
