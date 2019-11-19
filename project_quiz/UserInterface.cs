using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_quiz
{
    class UserInterface
    {
        private string answer;
        private int questionCount;
        private int correctCount;
        private Random numGen = new Random();

        private QuestionDatabase Database = new QuestionDatabase();

        
        public UserInterface()
        {
            this.questionCount = 0;
            this.correctCount = 0;
        }

        public void DisplayQuestion(Question question)
        {
            int questionIndex = numGen.Next();

            
        }

        public void DisplayCounter()
        {

        }
    }
}
