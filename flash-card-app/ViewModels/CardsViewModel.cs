using CommunityToolkit.Mvvm.ComponentModel;
using flash_card_app.Models;

namespace flash_card_app.ViewModels
{
    [QueryProperty("CardDeck", "CardDeckModel")]
    public partial class CardsViewModel : BaseViewModel
    {
        public CardsViewModel()
        {
            Title = "Cards";
        }

        [ObservableProperty]
        CardDeckModel cardDeckModel;
    }
}
