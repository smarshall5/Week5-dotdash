using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Week5
{
    public class EdEddEddyQuizViewModel
    {
        public EdEddEddyQuizViewModel(string question, EdEddEddy Ppoint, EdEddEddy NPoint)
        {
            Question = question;
            PositivePoint = Ppoint;
            NegativePoint = NPoint;
            Answer = Survey.Neutral;
        }

        public string Question { get; }
        public EdEddEddy PositivePoint { get; set; }
        public EdEddEddy NegativePoint { get; set; }
        public Survey Answer { get; set; }


        static EdEddEddyQuizViewModel() =>
            QuizQuestions = new ObservableCollection<EdEddEddyQuizViewModel>
            {
                new EdEddEddyQuizViewModel("Thinking is required",
                                           EdEddEddy.edd, EdEddEddy.ed),
                new EdEddEddyQuizViewModel("Scheming is required",
                                           EdEddEddy.eddy,EdEddEddy.edd),
                new EdEddEddyQuizViewModel("ButterToast is really tasty",
                                           EdEddEddy.ed, EdEddEddy.eddy),
                new EdEddEddyQuizViewModel("Farm life is only life",
                                           EdEddEddy.Rolph, EdEddEddy.eddy),
                new EdEddEddyQuizViewModel("Post it notes are the best way to identify things",
                                           EdEddEddy.edd, EdEddEddy.ed),
                new EdEddEddyQuizViewModel("brute force is a great solution followed by the power of imagination",
                                           EdEddEddy.ed, EdEddEddy.edd),
                new EdEddEddyQuizViewModel("Your brother is a very important part of your life",
                                           EdEddEddy.eddy, EdEddEddy.ed),
                new EdEddEddyQuizViewModel("Pigs make excellent steads",
                                           EdEddEddy.Rolph, EdEddEddy.edd)
            };

        public static ObservableCollection<EdEddEddyQuizViewModel> QuizQuestions { get; set; }

        public static EdEddEddy GradeQuiz()
        {
            var list = new List<int> { 0, 0, 0, 0 };
            foreach (var question in QuizQuestions)
            {
                switch (question.Answer)
                {
                    case Survey.Neutral: continue;                    
                    case Survey.Negative:
                        list[(int)question.NegativePoint] += 1;
                        list[(int)question.PositivePoint] -= 1;
                        break;
                    case Survey.Positive:
                        list[(int)question.NegativePoint] -= 1;
                        list[(int)question.PositivePoint] += 1;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch (list.IndexOf(list.Max()))
            {
                case 0: return EdEddEddy.ed;
                case 1: return EdEddEddy.edd;
                case 2: return EdEddEddy.eddy;
                case 3: return EdEddEddy.Rolph;
                default: return EdEddEddy.ed;
            }
        }
    }
}