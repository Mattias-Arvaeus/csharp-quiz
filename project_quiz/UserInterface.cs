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

        /*public void DisplayQuestion(Question aQuestion)
        {

        }*/

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

        public void SetQuestion(int questionNr)
        {
            String[] myKeys = new String[dictSize];
            String[] myValues = new String[dictSize];

            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            aQuestion = new Question(myKeys[questionNr], myValues[questionNr]);

            PrintQuestion(aQuestion);
        }

        public int GetRandomNr()
        {
            return numGen.Next(0, dictSize);
        }

    }
}
