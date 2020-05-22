using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalityQuizPage : ContentPage
    {
        public PersonalityQuizPage()
        {
            InitializeComponent();


        }

        private IRestClient _client = new RestClient("https://andruxnet-random-famous-quotes.p.rapidapi.com/?count=1");



        private void QuizList_OnItemTapped(object sender, ItemTappedEventArgs e)
      {
          var activeQuestion = (EdEddEddyQuizViewModel)e.Item;

          if (activeQuestion is null) return;
          QuestionLabel.Text = activeQuestion.Question;
          AnswerLabel.Text = activeQuestion.Answer.ToString();

          QuestionLabel.IsVisible = true;
          AnswerLabel.IsVisible = true;
          InputGrid.IsVisible = true;
      }



     private void N_Clicked(object sender, EventArgs e)
      {
          var activeQuestion = (EdEddEddyQuizViewModel)QuizList.SelectedItem;

          if (activeQuestion is null) return;
          activeQuestion.Answer = Survey.Negative;
          QuestionLabel.IsVisible = false;
          AnswerLabel.IsVisible = false;

          var indexOfActive = EdEddEddyQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
          EdEddEddyQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
          InputGrid.IsVisible = false;
      }

      private void Nu_Clicked(object sender, EventArgs e)
      {
          var activeQuestion = (EdEddEddyQuizViewModel)QuizList.SelectedItem;

          if (activeQuestion is null) return;
          activeQuestion.Answer = Survey.Neutral;
          QuestionLabel.IsVisible = false;
          AnswerLabel.IsVisible = false;

          var indexOfActive = EdEddEddyQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
          EdEddEddyQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
          InputGrid.IsVisible = false;
      }

      private void P_Clicked(object sender, EventArgs e)
      {
          var activeQuestion = (EdEddEddyQuizViewModel)QuizList.SelectedItem;

          if (activeQuestion is null) return;
          activeQuestion.Answer = Survey.Positive;
          QuestionLabel.IsVisible = false;
          AnswerLabel.IsVisible = false;

          var indexOfActive = EdEddEddyQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
          EdEddEddyQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
          InputGrid.IsVisible = false;
      }
     


        private void Submit_Quiz(object sender, EventArgs e)
        {
            var character = EdEddEddyQuizViewModel.GradeQuiz();
            int picture = Convert.ToInt32(EdEddEddyQuizViewModel.GradeQuiz());


            QuizResults.IsVisible = true;
            ResetButton.IsVisible = true;

            QuizList.IsVisible = false;
            QuestionLabel.IsVisible = false;
            AnswerLabel.IsVisible = false;
            InputGrid.IsVisible = false;
            SubmitButton.IsVisible = false;
            QuizPicture.IsVisible = true;
            switch (picture)
            {
                case 0:
                    QuizPicture.Source = "https://vignette.wikia.nocookie.net/edwikia/images/7/7c/Ed.1.png/revision/latest?cb=20120130210345";      
                break;
                case 1:
                    QuizPicture.Source = "https://vignette.wikia.nocookie.net/edwikia/images/7/72/Edd.1.png/revision/latest?cb=20120130210759";
                    break;
                case 2:
                    QuizPicture.Source = "https://vignette.wikia.nocookie.net/edwikia/images/c/cd/Eddy.png/revision/latest?cb=20170610052003";
                    break;
                case 3:
                    QuizPicture.Source = "https://vignette.wikia.nocookie.net/edwikia/images/6/64/Rolf_transparent.png/revision/latest?cb=20171030001040";
                    break;
                default:
                    QuizPicture.Source = "https://vignette.wikia.nocookie.net/edwikia/images/7/72/Edd.1.png/revision/latest?cb=20120130210759";
                    break;





            }
            var response = _client.Execute(new RestRequest(Method.GET));
            var quote = response != null && response.IsSuccessful
                ? JsonConvert.DeserializeObject<RandomQuote>(response.Content).quote : "The default quote is me'";
            QuizResults.Text = $"You are kind of like  {character}." +
                               $"The quote of the day is : {quote}";

        }

        private void Reset_Quiz(object sender, EventArgs e)
        {
            var toReset = EdEddEddyQuizViewModel.QuizQuestions.ToList();
            foreach (var question in toReset)
            {
                question.Answer = Survey.Neutral;

                var indexOfQuestion = EdEddEddyQuizViewModel.QuizQuestions.IndexOf(question);
                EdEddEddyQuizViewModel.QuizQuestions[indexOfQuestion] = question;
            }

            QuizResults.Text = string.Empty;
            QuizResults.IsVisible = false;
            ResetButton.IsVisible = false;

            QuizList.IsVisible = true;
            SubmitButton.IsVisible = true;
            QuizPicture.IsVisible = false;
        }

        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    var activeQuestion = (EdEddEddyQuizViewModel)QuizList.SelectedItem;

                    if (activeQuestion is null) return;
                    activeQuestion.Answer = Survey.Negative;
                    QuestionLabel.IsVisible = false;
                    AnswerLabel.IsVisible = false;

                    var indexOfActive = EdEddEddyQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
                    EdEddEddyQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
                    InputGrid.IsVisible = false;
                    break;
                case SwipeDirection.Right:
                     activeQuestion = (EdEddEddyQuizViewModel)QuizList.SelectedItem;

                    if (activeQuestion is null) return;
                    activeQuestion.Answer = Survey.Positive;
                    QuestionLabel.IsVisible = false;
                    AnswerLabel.IsVisible = false;

                     indexOfActive = EdEddEddyQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
                    EdEddEddyQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
                    InputGrid.IsVisible = false;
                    break;
               
            }
        }
    }
}