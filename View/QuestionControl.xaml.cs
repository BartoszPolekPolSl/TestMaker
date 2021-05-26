using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestMaker.View
{
    /// <summary>
    /// Logika interakcji dla klasy QuestionControl.xaml
    /// </summary>
    public partial class QuestionControl : UserControl
    {
        public QuestionControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty QuestionProperty =
            DependencyProperty.Register(
                nameof(Question),
                typeof(string),
                typeof(QuestionControl));
        public string Question
        {
            get { return (string)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }
        public static readonly DependencyProperty AnswersProperty =
            DependencyProperty.Register(
                nameof(Answers),
                typeof(string[]),
                typeof(QuestionControl));
        public string[] Answers
        {
            get { return (string[])GetValue(AnswersProperty); }
            set { SetValue(AnswersProperty, value); }
        }
        public static readonly DependencyProperty CorrectAnswerProperty =
            DependencyProperty.Register(
                nameof(CorrectAnswer),
                typeof(int),
                typeof(QuestionControl));
        public int CorrectAnswer
        {
            get { return (int)GetValue(CorrectAnswerProperty); }
            set { SetValue(CorrectAnswerProperty, value); }
        }
    }
}
