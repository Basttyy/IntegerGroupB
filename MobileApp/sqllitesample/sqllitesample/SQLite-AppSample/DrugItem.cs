using SQLite;

namespace sqllitesample.SQLite
{
    public class DrugItem
    {

        [PrimaryKey, AutoIncrement,]
        public int ID { get; set; }
        public string DrugName { get; set; }
        public string Dosage { get; set; }
        public string Diseases { get; set; }
        public string sideEffect { get; set; }
        public string manufacturer { get; set; }
    }
}