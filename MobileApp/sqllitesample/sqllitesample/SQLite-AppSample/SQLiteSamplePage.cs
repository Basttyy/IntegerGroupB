using SQLite;
using Xamarin.Forms;
using sqllitesample.SQLite.SQLite;

namespace sqllitesample.SQLite
{
    public class SQLiteSamplePage
    {
        private readonly SQLiteConnection _sqLiteConnection;

        public SQLiteSamplePage()
        {

            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            _sqLiteConnection.CreateTable<DrugItem>();

            // ADD
            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "Tutorial about SQLite",
                Dosage = ""
            });

            // UPDATE
            _sqLiteConnection.Update(new DrugItem
            {
                DrugName = "Creating a tutorial about SQLite",
                Dosage = "",
            });

            _sqLiteConnection.Insert(new DrugItem
            {
                DrugName = "Meeting Friends at 11 AM",
                Dosage = "",
            });

            // DELETE
            _sqLiteConnection.Delete<DrugItem>(2);
        }

        /// <summary>
        /// Gets a ContentPage that contains the items saved in the SQLite database.
        /// </summary>
        /// <returns></returns>
        public ContentPage GetSampleContentPage()
        {

            var entry = new Entry
            {
                Placeholder = "DrugName",
                WidthRequest = Device.OnPlatform<double>(300, 300, 260)
            };

            var switcher = new Switch();

            var addButton = new Button
            {
                Text = "Add DrugItem"
            };
            addButton.Clicked += (s, e) =>
            {
                _sqLiteConnection.Insert(new DrugItem
                {
                    DrugName = entry.Text,
                    Dosage = "",
                });
            };

            var listView = new ListView
            {
                ItemsSource = _sqLiteConnection.Table<DrugItem>()
            };

            var refreshButton = new Button
            {
                Text = "Refresh DrugItems"
            };
            refreshButton.Clicked += (s, e) =>
            {
                listView.ItemsSource = _sqLiteConnection.Table<DrugItem>();
            };

            var contentPage = new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "SQLite Sample",
                            FontSize = 50
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                entry,
                                switcher,
                            }
                        },
                        addButton,
                        refreshButton,
                        listView,
                    }
                }
            };
            return contentPage;
        }
    }
}
