using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        public MainPage()
        {
            this.InitializeComponent();

            // starta frågesporten
            // setup
            // gör databas
            QuestionDatabase database = new QuestionDatabase();

            // databas - > get deck
            deck = database.GetDeck();
            // deck->RemoveQuestion ger en fråga
            currentQuestion = deck.RemoveQuestion();

            // visa första frågan och svarsalternativen i GUI
            QuestionBlock.Text = currentQuestion.PrintQuestion();
            // spara frågan i en objektvariabel så att vi kan kolla om svaret är rätt



        }

        private void SubmitBtn1_Click(object sender, RoutedEventArgs e)
        { 
            // Kolla om detta alternativ är rätt
            // för statistik
            // visa statistik 4 av 8 och nästa fråga med alternativ
        }

        private void SubmitBtn2_Click(object sender, RoutedEventArgs e)
        {
            // Kolla om detta alternativ är rätt
            // för statistik
            // visa statistik 4 av 8 och nästa fråga med alternativ

        }

        private void SubmitBtn3_Click(object sender, RoutedEventArgs e)
        {
            // Kolla om detta alternativ är rätt
            // för statistik
            // visa statistik 4 av 8 och nästa fråga med alternativ

        }
    }
}
