using SQLite;

namespace flash_card_app.Models
{
    [Table("FlasCardCollection")]
    public class FlashCardCollectionModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CollectionFk { get; set; }
        public int FlashCardFk { get; set; }
    }
}
