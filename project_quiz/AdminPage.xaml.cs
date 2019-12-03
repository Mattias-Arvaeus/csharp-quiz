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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace project_quiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {
        QuestionDatabase database = new QuestionDatabase();
        public AdminPage()
        {
            this.InitializeComponent();
            SetUpDatabase();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void SetUpDatabase()
        {
            //QuestionDatabase database = new QuestionDatabase();

            bool success = await database.AddQuestionsFromFile();
            if (!success)
            {
                var messageDialog = new MessageDialog("Questions have not been loaded correctly.");
                await messageDialog.ShowAsync();
            }
        }             

        private void AddCountryTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            database.AddQuestionToDatabase(AddCountryTextbox.Text, AddCapitalTextbox.Text);
        }

        private void RemoveQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            database.RemoveQuestionsFromDatabase(RemoveQuestionTextbox.Text);
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void AddCapitalTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RemoveQuestionTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
