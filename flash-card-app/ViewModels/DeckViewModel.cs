using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Views;
using System.Collections.ObjectModel;
//Notes: We need some way to edit the card deck & be able to delete it. All cards that are in that deck also be deleted. First Delete Cards then The Deck.

namespace flash_card_app.ViewModels
{
    public partial class DeckViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler errorHandler = new();

        public ObservableCollection<DeckModel> ODeckModel { get; } = new();
        public DeckViewModel()
        {
            Title = "My Decks";
        }

        [RelayCommand]
        async Task GetCardDecks()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                ODeckModel.Clear();

                var repo = await App.Context.GetRepository<DeckModel>();
                var collection = await repo.GetAll();
                List<DeckModel> decks = collection.ToList();

                foreach (var item in decks)
                {
                    ODeckModel.Add(item);
                }
            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task NavigateToCreateDeckPage()
        {
            await Shell.Current.GoToAsync(nameof(CreateDeckPage));
        }

        [RelayCommand]
        async Task NavigateToCardsPage(DeckModel deckModel)
        {
            if (deckModel is null)
                return;

            await Shell.Current.GoToAsync(nameof(CardsPage), true,
                new Dictionary<string, object>
                {
                    {"Deck", deckModel }
                });
        }

        [RelayCommand]
        static async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
