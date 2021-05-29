using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaker.ViewModel
{
    using Model;
    using System.Windows.Input;

    class TestMakerViewModel : ViewModel
    {
        public TestMakerViewModel()
        {
            questionList = new TestQuestionsList();
            currentQuestion = new TestQuestion();
            indexOfCurrentQuestion = 0;
        }
        private TestQuestionsList questionList;
        private TestQuestion currentQuestion;
        private int indexOfCurrentQuestion;
        #region Properties
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
        #endregion Properties

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
                            indexOfCurrentQuestion++;
                            if (indexOfCurrentQuestion == questionList.LengthOfQuestionList+1)
                            {                            
                                questionList.AddQuestion(currentQuestion);
                                currentQuestion = new TestQuestion();                               
                            }
                            else
                            {
                                currentQuestion = questionList[indexOfCurrentQuestion-1];
                            }
                            OnPropertyChange(nameof(CurrentAnswers), nameof(CurrentQuestion), nameof(CorrectAnswer));
                        },
                        arg=>true); 
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
                            indexOfCurrentQuestion--;
                            currentQuestion = questionList[indexOfCurrentQuestion];                           
                            OnPropertyChange(nameof(CurrentAnswers), nameof(CurrentQuestion), nameof(CorrectAnswer));
                        },
                        arg=>indexOfCurrentQuestion>=0);
                }
                return previousQuestoin;
            }       
        }
        #endregion Commands
        //private bool IfAllFieldsFilled()
        // {
        //     if(currentQuestion.Answers.&&currentQuestion.CorrectAnswer)
        // }
    }
}
