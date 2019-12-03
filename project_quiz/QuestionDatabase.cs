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
                string databasetext = await FileIO.ReadTextAsync(databaseCapital);
                FormatDatabase(databasetext);

                noQuestions = databas.Count;
                noRightAnswear = 0;
                return true;
            }
            catch (SystemException)
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
                databas.Add(landStad[0], landStad [1]);
            }
        }

        public async void AddQuestionToDatabase(string country,string capital)
        {
            // lägg till i dictionary
            /*
            databas.Add(country, capital);
            // skriv dictionary till fil som 
            keyCollection = databas.Keys;
            valueCollection = databas.Values;

            String[] myKeys = new String[databas.Count];
            String[] myValues = new String[databas.Count];

            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            string textToFile = "";
            foreach(String countryKey in databas.Keys)
            {

                for (int i = 0; i < databas.Count; i++)
                {
                    textToFile = $"{Environment.NewLine}{myKeys[i]},{myValues[i]}";

                    StorageFile capitalFile = await AwaitDatabase();
                    await FileIO.AppendTextAsync(capitalFile, textToFile);
                }
                
                //textToFile = $"{countryKey},{databas.}"
            }*/
            // land1,huvudstad1
            // land2,huvudstad2
            // ...
            
            string addedQuestion = $"{Environment.NewLine}{country},{capital}";
            StorageFolder storagefolder = ApplicationData.Current.LocalFolder;
            StorageFile databaseCapital = await storagefolder.GetFileAsync("databasecapital.txt");

            await FileIO.AppendTextAsync(databaseCapital, addedQuestion);
            
        }
        public async void RemoveQuestionsFromDatabase(string country)
        {
            
        }

        private async Task<StorageFile> AwaitDatabase()
        {
            StorageFolder storagefolder = ApplicationData.Current.LocalFolder;
            StorageFile databaseCapital = await storagefolder.GetFileAsync("databasecapital.txt");
            return databaseCapital;   
        }
    }
}
