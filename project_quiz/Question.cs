using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_quiz
{
    class Question
    {
        private string land;
        private string answer;

        public Question(string land, string answer)
        {
            this.land = land;
            this.answer = answer;
        }

        public bool CheckAnswer(string userAnswer)
        {
            if (userAnswer == this.answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Land
        {
            get
            {
                return land;
            }
        }

        public string Answer
        {
            get
            {
                return answer;
            }
        }
    }
}
