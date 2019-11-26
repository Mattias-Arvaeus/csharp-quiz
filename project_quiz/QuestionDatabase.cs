using System;
using System.Collections;
using System.Collections.Specialized;

namespace project_quiz
{
    public class QuestionDatabase
    {
        OrderedDictionary databas = new OrderedDictionary()
            {
                {"Sverige", "Stockholm"},
                {"Danmark", "Köpenhamn"},
                {"Norge", "Oslo"},
                { "Finland", "Helsingfors"}
            };

        public QuestionDatabase()
        {
            
        }

        public Deck GetDeck()
        {
            Deck deck = new Deck();
            Question question = new Question("land", "answer", "fel 1", "fel 2");
            deck.AddQuestion(question);
            return deck;
        }

        public OrderedDictionary GetDatabase()
        {
            return databas;
        }
        /*
        public Question SetQuestion(int questionNr)
        {
            String[] myKeys = new String[dictSize];
            String[] myValues = new String[dictSize];

            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            aQuestion = new Question(myKeys[questionNr], myValues[questionNr]);

            return aQuestion;
        }
        */
        public Question question()
        {
            return null;
        }
        /*
        public int GetRandomNr()
        {
            return numGen.Next(0, dictSize);
        }
        */

    }
}
