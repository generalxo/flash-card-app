namespace flash_card_app.Models
{
    class OptionCardModel
    {
        // public int OptionCardId { get; set; } add when starting with Sqlite
        public string Question { get; set; }
        public string CorrectOption { get; set; }
        public List<string> Options { get; set; }
        public int Streak { get; set; }
    }
}
