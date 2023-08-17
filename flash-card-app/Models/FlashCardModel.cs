using SQLite;

namespace flash_card_app.Models
{
    //No way of adding ForeginKeys for some reason. Will have to create SQL Query to add them.

    [Table("FlashCard")]
    public class FlashCardModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Question { get; set; }
        [MaxLength(250)]
        public string Answer { get; set; }
        [NotNull]
        public int Streak { get; set; } = 0;

    }
}
