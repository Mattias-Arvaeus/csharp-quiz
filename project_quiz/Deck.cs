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
        List<Question> questions = new List<Question>();
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
            Question question = questions[questions.Count - 1];
            questions.RemoveAt(questions.Count - 1);
            return question;
        }

        public void Shuffle()
        {

        }
    }
}
