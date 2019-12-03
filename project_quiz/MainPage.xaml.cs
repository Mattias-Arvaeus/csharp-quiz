using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace project_quiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Deck deck;
        private Question currentQuestion;
        public int score { get; set; }
        public int noOfQuestions { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            // starta frågesporten
            // setup
            // gör databas
            SetUpDeckOfQuestionCards();

            // visa första frågan och svarsalternativen i GUI

            // spara frågan i en objektvariabel så att vi kan kolla om svaret är rätt
        }

        private async void SetUpDeckOfQuestionCards()
        {
            QuestionDatabase database = new QuestionDatabase();

            bool success = await database.AddQuestionsFromFile();
            if (!success)
            {
                var messageDialog = new MessageDialog("Questions have not been loaded correctly.");
                await messageDialog.ShowAsync();
            }
            // databas - > get deck
            deck = database.MakeDeck();
            noOfQuestions = deck.CountQuestions();

            // deck->RemoveQuestion ger en fråga
            SetQuestions();

        }
        private void SubmitBtn1_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion.CheckAnswer(SubmitBtn1.Content.ToString()))
            {
                AddCounter();
                SetQuestions();          
            }
            else
            {
                SetQuestions();
            }
        }

        private void SubmitBtn2_Click(object sender, RoutedEventArgs e)
        {

            if (currentQuestion.CheckAnswer(SubmitBtn2.Content.ToString()))
            {
                AddCounter();
                SetQuestions();
                
            }
            else
            {
                SetQuestions();
            }
        }

        private void SubmitBtn3_Click(object sender, RoutedEventArgs e)
        {

            if (currentQuestion.CheckAnswer(SubmitBtn3.Content.ToString()))
            {
                AddCounter();
                SetQuestions();
                
            }
            else
            {
                SetQuestions();
            }
        }

        private void SetQuestions()
        {
            if (deck.IfListIsZero())
            {
                QuestionBlock.Text = $"Slut på frågor. Du fick { score } av { noOfQuestions } poäng ";

                SubmitBtn1.Visibility = Visibility.Collapsed;
                SubmitBtn2.Visibility = Visibility.Collapsed;
                SubmitBtn3.Visibility = Visibility.Collapsed;
                QuestionNumber.Visibility = Visibility.Collapsed;
                
            }
            else
            {
                currentQuestion = deck.RemoveQuestion();

                QuestionBlock.Text = currentQuestion.PrintQuestion();

                SubmitBtn1.Content = currentQuestion.svarsalternativ[0];
                SubmitBtn2.Content = currentQuestion.svarsalternativ[1];
                SubmitBtn3.Content = currentQuestion.svarsalternativ[2];
            }
            
        }

        private void AddCounter()
        {
            score++;
            QuestionNumber.Text = score.ToString();
            
        }

        private void Adminbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }
    }
}