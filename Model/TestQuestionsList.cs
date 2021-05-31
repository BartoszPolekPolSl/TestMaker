using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaker.Model
{
    public class TestQuestionsList
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

        public TestQuestion this[int index]
        {
            get { return listOfQuestions[index]; }
        }

        public void AddQuestion(TestQuestion q)
        {
            listOfQuestions.Add(q);
        }
        
        public int LengthOfQuestionList
        {
            get
            {
                return listOfQuestions.Count;
            }
        }
    }
}
