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
            dictSize = myOrderedDictionary.Count;
        }

        public string GetKey(ICollection keyCollection, int dictionarySize, int index)
        {
            String[] myKeys = new String[dictionarySize];
            keyCollection.CopyTo(myKeys, 0);
            return myKeys[index];
        }

        public string GetValue(ICollection valueCollection, int dictionarySize, int index)
        {
            String[] myValues = new String[dictionarySize];
            valueCollection.CopyTo(myValues, 0);

            return myValues[index];
        }

    }
}
