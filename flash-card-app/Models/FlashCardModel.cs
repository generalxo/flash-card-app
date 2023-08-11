namespace flash_card_app.Models
{
    internal class FlashCardModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Streak { get; set; } = 0;

    }
}
