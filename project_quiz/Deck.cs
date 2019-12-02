using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_quiz
{
    public class Deck
    {
        // lista med frågor
        public List<Question> questions = new List<Question>();
        public int NoOfQuestions;

        Random rnd = new Random();
        public Deck()
        {

        }

        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }

        public Question RemoveQuestion()
        {
            // ta bort sista frågan
            if (questions.Count == 0)
            {
                return null;
            }
            else
            {
                Question question = questions[questions.Count - 1];
                questions.RemoveAt(questions.Count - 1);
                return question;
            }
        }

        public void Shuffle()
        {

        }
        public bool IfListisZero()
        {
            if (questions.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CountQuestions()
        {
            return questions.Count;
        }
    }
}
