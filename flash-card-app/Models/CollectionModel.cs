using SQLite;
namespace flash_card_app.Models
{
    [Table("Collection")]
    public class CollectionModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
