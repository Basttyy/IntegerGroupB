using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using sqllitesample.SQLite;
using sqllitesample.SQLite.SQLite;

namespace sqllitesample
{
    public partial class MainPage : ContentPage
    {
        private readonly SQLiteConnection _sqLiteConnection;
        public MainPage()
        {
            InitializeComponent();

            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            _sqLiteConnection.CreateTable<DrugItem>();

            _sqLiteConnection.DeleteAll<DrugItem>();

            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "coartem",
                Diseases = "malaria",
                Dosage = "Children: 2, Adult: 4 - morning and night",                
                sideEffect= "abdominal pain,chills, cough, muscle aches, sore throat",
                manufacturer= "m&n",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "artemeter",
                Diseases = "malaria",
                Dosage = "Children: 2, Adult: 4 - morning and night",
                sideEffect = "headache, abdominal pain, racing heartbeat or pulse, pale skin",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "malarone",
                Diseases = "malaria",
                Dosage = "Children: 1, Adult: 2 - daily",
                sideEffect = "chills, convulsions, racing heartbeat, itching, weakness",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "plaquenil",
                Diseases = "malaria",
                Dosage = "Children: 2, Adult: 4",
                sideEffect = "mental disorder, nervousness, dizziness, eye disorder",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "chloroquine",
                Diseases = "malaria",
                Dosage = "Children: 1, Adult: 2 - daily",
                sideEffect = "anxiety, stomach pains, bleeding gums, chills, cold sweats",
                manufacturer = "",
            });


            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "ciprofloxacine",
                Diseases = "typhoid",
                Dosage = "Children: 1, Adult: 2 - morning and night",
                sideEffect = "chills, confusion, diarrhea",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "ceftriaxone",
                Diseases = "typhoid",
                Dosage = "Children: 1, Adult: 2 - daily",
                sideEffect = "chest pain, cough, fever, chills",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "cipro",
                Diseases = "typhoid",
                Dosage = "Children: 1, Adult: 2 - morning and night",
                sideEffect = "diarrhea, confusion, night mare, change in urination, change in skin color",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "zithromax",
                Diseases = "typhoid",
                Dosage = "1 tablets daily",
                sideEffect = "loose stools, diarhea, swelling, fever",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "ampicillin",
                Diseases = "typhoid",
                Dosage = "Children: 1, Adult: 2 - morning and night",
                sideEffect = "diarhea, nervousness, rash",
                manufacturer = "",
            });


            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "cymbalta",
                Diseases = "depression",
                Dosage = "2 tablets daily",
                sideEffect = "blindness, area rash, abdominal pain, cold sweat",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "zoloft",
                Diseases = "depression",
                Dosage = "2 tablets daily",
                sideEffect = "confusion, diarhea, weakness",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "lexapro",
                Diseases = "depression",
                Dosage = "1 tablet daily",
                sideEffect = "coma, confusion, convulsion, dizziness",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "prozac",
                Diseases = "depression",
                Dosage = "Children: 1, Adult 2: daily",
                sideEffect = "restlessness,fever, muscle pain, excessive hunger",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "celexa",
                Diseases = "depression",
                Dosage = "2 tablet daily",
                sideEffect = "agitation, blurred vision, loss of memory, fever",
                manufacturer = "",
            });


            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "lisinopril",
                Diseases = "blood pressure",
                Dosage = "2 tablets daily",
                sideEffect = "chest pain, chills, cough, common cold, headache",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "benicar",
                Diseases = "blood pressure",
                Dosage = "2 tablets daily",
                sideEffect = "ear congestion, loss of voice, body pain, sneezing",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "losartan",
                Diseases = "blood pressure",
                Dosage = "2 tablets daily",
                sideEffect = "bladder pain, anxiety, nightmares, increase hunger",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "norvasc",
                Diseases = "blood pressure",
                Dosage = "1 tablet daily",
                sideEffect = "dizziness, feeling warmth, racing heart, difficult breathing",
                manufacturer = "",
            });
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "cozaar",
                Diseases = "blood pressure",
                Dosage = "2 tablets daily",
                sideEffect = "coma, depression, abdominal pain, bladder pain",
                manufacturer = "",
            });

            MainListView.ItemsSource = _sqLiteConnection.Table<DrugItem>();

            MainListView.ItemTapped += async (sender, e) =>
            {
                var item = e.Item as DrugItem;
                await Navigation.PushAsync(new DrugDetailPage(item.DrugName, item.Diseases, item.Dosage, item.sideEffect));
                MainListView.SelectedItem = null;
            };
            About.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new AboutPage());
            };
        }
        private void onText_Changed(object sender, EventArgs e)
        {
            if(!(MainSearchBar.Text == ""))
            {
                string keyword = MainSearchBar.Text;

                var searchResult = _sqLiteConnection.Table<DrugItem>().Where(u => u.DrugName.Contains(keyword));
                MainListView.ItemsSource = searchResult;
            }
            else
            {
                MainListView.ItemsSource = _sqLiteConnection.Table<DrugItem>();
            }            
        }
    }
}
