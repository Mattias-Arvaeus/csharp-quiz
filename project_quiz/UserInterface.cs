using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace project_quiz
{
    class UserInterface
    {
        private string question;
        private int questionNr;
        private string answer;
        private int questionCount;
        private int correctCount;
        private int dictSize;

        ICollection keyCollection;
        ICollection valueCollection;

        private Random numGen = new Random();

        private QuestionDatabase theDatabase = new QuestionDatabase();

        OrderedDictionary dict = new OrderedDictionary();

        public Question aQuestion;

        
        public UserInterface()
        {
            this.questionCount = 0;
            this.correctCount = 0;
        }

        public string PrintQuestion(Question question)
        {
            return string.Format("vilken är {0} huvudstad?", question.Land);
        }

        public void DisplayCounter()
        {
            questionCount += 1;
            //
        }

        public void GetQuestionFromDatabase()
        {
            dict = theDatabase.GetDatabase();

            this.keyCollection = dict.Keys;
            this.valueCollection = dict.Values;
            this.dictSize = dict.Count;
        }

        
        public string SetAlt(int questionNr)
        {
            String[] myValues = new String[dictSize];

            valueCollection.CopyTo(myValues, 0);

            return  myValues[questionNr];

        }

        

    }
}
