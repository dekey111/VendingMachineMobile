using SQLite;

namespace VendingMachineMobile.dataFiles
{
    [Table ("Drinks")]
    public class Drinks
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdDrinks { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
    }
}
