using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaker.Model
{
    public class Test
    {


        public Test()
        {
            questionList = new TestQuestionsList();
        }

        public TestQuestionsList questionList;
        public string NameOfTest { get; set; }

        public void SaveTest(string path)
        {
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine(NameOfTest);
                for(int i =0; i<questionList.LengthOfQuestionList; i++)
                {
                    writer.WriteLine(questionList[i].Question);
                    for(int k = 0; k < 4; k++)
                    {
                        if (questionList[i].CorrectAnswer == k)
                        {
                            writer.WriteLine($"1|{questionList[i].Answers[k]}");
                        }
                        else
                        {
                            writer.WriteLine($"0|{questionList[i].Answers[k]}");
                        }
                    }
                    writer.WriteLine("**********");
                }
            }
        }

        public void LoadTest(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                NameOfTest = lines[0];
                for (int i = 1; i < lines.Length; i = i + 6)
                {
                    int correctAnswer;
                    string question = lines[i];
                    if (lines[i + 1][0] == '1')
                    {
                        correctAnswer = 0;
                    }
                    else if(lines[i + 2][0] == '1')
                    {
                        correctAnswer = 1;
                    }
                    else if(lines[i + 3][0] == '1')
                    {
                        correctAnswer = 2;
                    }
                    else
                    {
                        correctAnswer = 3;
                    }
                    string[] answers = { lines[i + 1].Remove(0,2), lines[i + 2].Remove(0, 2), lines[i + 3].Remove(0, 2), lines[i + 4].Remove(0, 2) };
                    questionList.AddQuestion(new TestQuestion(question, answers, correctAnswer));
                }
            }
        }
    }
}
