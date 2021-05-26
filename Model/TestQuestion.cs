using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaker.Model
{
    public class TestQuestion
    {
        public string Question { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }

        public TestQuestion(string question, string[] answers, int correctAnswer)
        {
            Question = question;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }
}
