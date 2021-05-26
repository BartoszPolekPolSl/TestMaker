using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaker.Model
{
    class TestQuestionsList
    {
        private List<TestQuestion> listOfQuestions;
        public TestQuestionsList()
        {
            listOfQuestions = new List<TestQuestion>();
        }
        public TestQuestionsList(List<TestQuestion> listOfQuestions)
        {
            this.listOfQuestions = listOfQuestions;
        }
        public void AddQuestion(TestQuestion q)
        {
            listOfQuestions.Add(q);
        }
    }
}
