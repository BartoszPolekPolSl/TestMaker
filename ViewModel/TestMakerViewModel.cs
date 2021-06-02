using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaker.ViewModel
{
    using Microsoft.Win32;
    using Model;
    using System.Windows;
    using System.Windows.Input;

    class TestMakerViewModel : ViewModel
    {
        public TestMakerViewModel()
        {
            test = new Test();
            currentQuestion = new TestQuestion();
            indexOfCurrentQuestion = 0;
        }
        #region Private fields
        private Test test;
        private TestQuestion currentQuestion;
        private int indexOfCurrentQuestion;
        #endregion Private fields

        #region Binded properties 
        public string CurrentQuestion
        {
            get
            {
                return currentQuestion.Question;
            }
            set
            {
                currentQuestion.Question = value;
                OnPropertyChange(nameof(CurrentQuestion));
            }
        }  
        public string[] CurrentAnswers
        {
            get
            {
                return currentQuestion.Answers;
            }
            set
            {
                currentQuestion.Answers = value;
                OnPropertyChange(nameof(CurrentAnswers));
            }
        }     
        public int? CorrectAnswer
        {
            get
            {
                return currentQuestion.CorrectAnswer;
            }
            set
            {
                currentQuestion.CorrectAnswer = value;
                OnPropertyChange(nameof(CorrectAnswer));
            }
        }
        public string NameOfTest
        {
            get
            {
                return test.NameOfTest;
            }
            set
            {
                test.NameOfTest = value;
                OnPropertyChange(nameof(NameOfTest));
            }
        }
        #endregion Binded properties

        #region Commands
        private ICommand nextQuestion;
        public ICommand NextQuestion
        {
            get
            {
                if (nextQuestion == null)
                {
                    nextQuestion = new RelayCommand(
                        arg=> 
                        {
                            getNextQuestion();
                            OnPropertyChange(nameof(CurrentAnswers), nameof(CurrentQuestion), nameof(CorrectAnswer));
                        },
                        arg=>!string.IsNullOrWhiteSpace(CurrentAnswers[0])&& !string.IsNullOrWhiteSpace(CurrentAnswers[1])&& !string.IsNullOrWhiteSpace(CurrentAnswers[2])&& !string.IsNullOrWhiteSpace(CurrentAnswers[3])&& !string.IsNullOrWhiteSpace(CurrentQuestion)&&CorrectAnswer!=null); 
                }
                return nextQuestion;
            }
        }
        private ICommand previousQuestoin;
        public ICommand PreviousQuestoin
        {
            get
            {
                if (previousQuestoin == null)
                {
                    previousQuestoin = new RelayCommand(
                        arg =>
                        {
                            getPreviousQuestion();
                            OnPropertyChange(nameof(CurrentAnswers), nameof(CurrentQuestion), nameof(CorrectAnswer));
                        },
                        arg=>indexOfCurrentQuestion>0);
                }
                return previousQuestoin;
            }       
        }
        private ICommand saveTest;
        public ICommand SaveTest
        {
            get
            {
                if (saveTest == null)
                {
                    saveTest = new RelayCommand(
                        arg =>
                        {
                            SaveFileDialog dialog = new SaveFileDialog();
                            dialog.Filter = "Text File(*.txt)|*.txt";
                            dialog.DefaultExt = ".txt";
                            if (dialog.ShowDialog() == true)
                            {
                                if (indexOfCurrentQuestion == test.questionList.LengthOfQuestionList)
                                {
                                    test.questionList.AddQuestion(currentQuestion);
                                    test.SaveTest(dialog.FileName);
                                }
                                else
                                {
                                    test.SaveTest(dialog.FileName);
                                }                           
                            }
                        },
                        arg=>!string.IsNullOrWhiteSpace(NameOfTest));
                }
                return saveTest;
            }
        }
        private ICommand loadTest;
        public ICommand LoadTest
        {
            get
            {
                if (loadTest == null)
                {
                    loadTest = new RelayCommand(
                        arg =>
                        {
                            OpenFileDialog dialog = new OpenFileDialog();
                            dialog.Filter = "Text File(*.txt)|*.txt";
                            dialog.DefaultExt = ".txt";
                            if (dialog.ShowDialog() == true)
                            {
                                test = new Test();
                                test.LoadTest(dialog.FileName);
                            }
                            indexOfCurrentQuestion = 0;
                            currentQuestion = test.questionList[0];
                            OnPropertyChange(nameof(CurrentAnswers), nameof(CurrentQuestion), nameof(CorrectAnswer), nameof(NameOfTest));
                        },
                        arg=>true
                        );
                }
                return loadTest;
            }
        }
        private ICommand instruction;
        public ICommand Instruction
        {
            get
            {
                if (instruction == null)
                {
                    instruction = new RelayCommand(
                        arg =>
                        {
                            MessageBox.Show("The program is used to create tests. In the first field enter the name of the test, and in the next fields enter the question and 4 answers. Mark the right answer. To confirm a question and move to the next one click \"Next\" button. After creating the test, save it by clicking \"Save\" and selecting a file name and location. You can also edit existing tests by loading them with \"Load\" button.", "Instruction", MessageBoxButton.OK, MessageBoxImage.Information);
                        },
                        arg => true
                        );
                }
                return instruction;
            }
        }
        #endregion Commands

      private void getNextQuestion()
        {
            indexOfCurrentQuestion++;
            try
            {
                currentQuestion = test.questionList[indexOfCurrentQuestion];

            }
            catch (ArgumentOutOfRangeException e)
            {
                if (indexOfCurrentQuestion == test.questionList.LengthOfQuestionList)
                {
                    currentQuestion = new TestQuestion();
                }
                else
                {
                    test.questionList.AddQuestion(currentQuestion);
                    currentQuestion = new TestQuestion();
                }
            }
        }
      private void getPreviousQuestion()
        {
            indexOfCurrentQuestion--;
            currentQuestion = test.questionList[indexOfCurrentQuestion];
        }
    }
}
