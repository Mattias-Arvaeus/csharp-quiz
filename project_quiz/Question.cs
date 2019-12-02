using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace project_quiz
{
    public class Question
    {
        private string land; 
        private string answer;

        public List<string> svarsalternativ;
        Random numGen = new Random();

        public Question(string land, string answer, string fel1, string fel2)
        {
            this.land = land;
            this.answer = answer;

            svarsalternativ = new List<string>();
            svarsalternativ.Add(answer);
            svarsalternativ.Add(fel1);
            svarsalternativ.Add(fel2);

            for (int i = 0; i < 10; i++)
            {
                int random = numGen.Next(0, svarsalternativ.Count);
                int random1 = numGen.Next(0, svarsalternativ.Count);

                string temp = svarsalternativ[random];
                svarsalternativ[random] = svarsalternativ[random1];
                svarsalternativ[random1] = temp;

                i++;
            }
        }

        public List<string> Getoptions()
        {
            return svarsalternativ;
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
        public string PrintQuestion()
        {
            return $"vad är { land }s huvudstad?";
        }

        public List<string> Alternativ()
        {
            return svarsalternativ;
        }

    }
}
