using System;
using System.Collections;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Windows.Storage;

namespace project_quiz
{
    public class QuestionDatabase
    {
        Random rnd = new Random();

        public int noQuestions { get; set; }
        public int noRightAnswear { get; set; }

        ICollection keyCollection;
        ICollection valueCollection;

        OrderedDictionary databas = new OrderedDictionary();
        

        public QuestionDatabase()
        {

        }
        // nödlösning
        private void BackupQuestions()
        {
            databas = new OrderedDictionary()
            {
                {"Sverige", "Stockholm"},
                {"Danmark", "Köpenhamn"},
                {"Norge", "Oslo"},
                { "Finland", "Helsingfors"},
                {"Island", "Reykjavik"},
                {"Storbritannien", "London" },
                {"Frankrike", "Paris" },
                {"Tyskland", "Berlin" },
                {"Polen", "Warszawa" },
                {"Spanien", "Madrid" },
                {"Portugal", "Lissabon" },
                {"Nederländerna", "Amsterdam" },
                {"Italien", "Rom" },
                {"Österrike", "Wien" },
                {"Tjeckien", "Prag" }
            };
        }

        public async Task<bool> AddQuestionsFromFile()
        {
            
            try
            {
                StorageFile databaseCapital = await AwaitDatabase();
                string databaseText = await FileIO.ReadTextAsync(databaseCapital);
                FormatDatabase(databaseText);

                noQuestions = databas.Count;
                noRightAnswear = 0;
                return true;
            }
            catch (SystemException e)
            {
                BackupQuestions();
                return false;
                
            }
        }
        public Deck MakeDeck()
        {
            keyCollection = databas.Keys;
            valueCollection = databas.Values;

            Deck deck = new Deck();
            String[] myKeys = new String[databas.Count];
            String[] myValues = new String[databas.Count];

            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            for (int i = 0; i < databas.Count; i++)
            {
                String[] fel = AnswearAlternatives();

                while (!TestEqualAlternatives(myValues, fel, i))
                {
                    fel = AnswearAlternatives();
                }
                Question aQuestion = new Question(myKeys[i], myValues[i], fel[0], fel[1]);
                deck.AddQuestion(aQuestion);
            }
            return deck;
        }

        public String[] AnswearAlternatives()
        {

            valueCollection = databas.Values;
            String[] myValues = new String[databas.Count];
            valueCollection.CopyTo(myValues, 0);

            String[] newValues = new string[2];
            for (int i = 0; i < 2; i++)
            {
                int random = rnd.Next(0, databas.Count - 1);
                newValues[i] = myValues[random];
            }
            return newValues;
        }

        public bool TestEqualAlternatives(String[]answear, String[] fel, int index)
        {
            if (answear[index] != fel[0] && answear[index] != fel[1])
            {
                if (fel[0] != fel[1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void FormatDatabase(string database)
        {
            String[] pairs = database.Split(Environment.NewLine);
            foreach (string pair in pairs)
            {
                String[] landStad = pair.Split(',');
                if (landStad.Length > 1)
                {
                    databas.Add(landStad[0], landStad[1]);
                }
                else
                {
                    // felaktig rad
                }
                
            }
        }

        public async void AddQuestionToDatabase(string country,string capital)
        {
            //TODO -- Check if question exists in database

            // lägg till i dictionary
            
            databas.Add(country, capital);
            // skriv dictionary till fil som 
            keyCollection = databas.Keys;
            valueCollection = databas.Values;

            String[] myKeys = new String[databas.Count];
            String[] myValues = new String[databas.Count];

            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            string textToFile = "";
            StorageFile databaseCapital = await AwaitDatabase();

            //foreach (String countryKey in databas.Keys)
            //{

                for (int i = 0; i < databas.Keys.Count; i++)
                {
                    textToFile += $"{myKeys[i]},{myValues[i]}{Environment.NewLine}";
                }
            //}
            await FileIO.WriteTextAsync(databaseCapital, textToFile);
        }

        public async void RemoveQuestionsFromDatabase(string country)
        {
            if (databas.Contains(country))
            {
                keyCollection = databas.Keys;
                valueCollection = databas.Values;
                string textToFile = "";

                String[] myKeys = new String[databas.Count];
                String[] myValues = new String[databas.Count];

                keyCollection.CopyTo(myKeys, 0);
                valueCollection.CopyTo(myValues, 0);

                databas.Remove(country);

                StorageFile databaseCapital = await AwaitDatabase();

                for (int i = 0; i < databas.Keys.Count; i++)
                {
                    textToFile += $"{myKeys[i]},{myValues[i]}{Environment.NewLine}";
                }
                await FileIO.WriteTextAsync(databaseCapital, textToFile);

            }

        }

        private async Task<StorageFile> AwaitDatabase()
        {
            StorageFolder storagefolder = ApplicationData.Current.LocalFolder;
            StorageFile databaseCapital = await storagefolder.GetFileAsync("databasecapital.txt");
            return databaseCapital;
        }
    }
}