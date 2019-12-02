using System;
using System.Collections;
using System.Collections.Specialized;

namespace project_quiz
{
    public class QuestionDatabase
    {
        Random rnd = new Random();

        public int noQuestions { get; set; }
        public int noRightAnswear { get; set; }

        ICollection keyCollection;
        ICollection valueCollection;

        OrderedDictionary databas = new OrderedDictionary()
            {
                {"Sverige", "Stockholm"},
                {"Danmark", "Köpenhamn"},
                {"Norge", "Oslo"},
                { "Finland", "Helsingfors"},
                {"Island", "Reykjavik"},
                {"Storbritannien", "London" },
                {"Frankrike", "Paris" },
                {"Tyskland", "Berlin" },
                {"Polen", "Warszawa" },
                {"Spanien", "Madrid" },
                {"Portugal", "Lissabon" },
                {"Nederländerna", "Amsterdam" },
                {"Italien", "Rom" },
                {"Österrike", "Wien" },
                {"Tjeckien", "Prag" }
            };

        public QuestionDatabase()
        {
            noQuestions = databas.Count;
            noRightAnswear = 0;
        }
        public Deck MakeDeck()
        {
            keyCollection = databas.Keys;
            valueCollection = databas.Values;

            Deck deck = new Deck();
            String[] myKeys = new String[databas.Count];
            String[] myValues = new String[databas.Count];

            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            for (int i = 0; i < databas.Count; i++)
            {
                String[] fel = AnswearAlternatives();

                while (!TestEqualAlternatives(myValues, fel, i))
                {
                    fel = AnswearAlternatives();
                }
                Question aQuestion = new Question(myKeys[i], myValues[i], fel[0], fel[1]);
                deck.AddQuestion(aQuestion);
            }
            return deck;
        }

        public String[] AnswearAlternatives()
        {

            valueCollection = databas.Values;
            String[] myValues = new String[databas.Count];
            valueCollection.CopyTo(myValues, 0);

            String[] newValues = new string[2];
            for (int i = 0; i < 2; i++)
            {
                int random = rnd.Next(0, databas.Count - 1);
                newValues[i] = myValues[random];
            }
            return newValues;
        }

        public string PrintScore(int AnswearAsBool)
        {
            noRightAnswear += AnswearAsBool;
            string s = $"{ noRightAnswear } / {noQuestions }";
            return s;

        }
        //TODO - FIx
        public bool TestEqualAlternatives(String[]answear, String[] fel, int index)
        {
            if (answear[index] != fel[0] && answear[index] != fel[1])
            {
                if (fel[0] != fel[1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
