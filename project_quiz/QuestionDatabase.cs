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

        public OrderedDictionary GetDatabase()
        {
            return databas;
        }

    }
}
