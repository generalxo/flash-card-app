using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Views;
using System.Collections.ObjectModel;

namespace flash_card_app.ViewModels
{
    public partial class DeckViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler errorHandler = new();

        public ObservableCollection<DeckModel> ObservableDecks { get; } = new();
        public DeckViewModel()
        {
            Title = "My Decks";
        }

        // OnAppearing Commands 
        [RelayCommand]
        async Task GetDecks()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var repo = await App.Context.GetRepository<DeckModel>();

                if (ObservableDecks.Count > 0)
                {
                    ObservableDecks.Clear();
                }

                var collection = await repo.GetAll();
                List<DeckModel> decks = collection.ToList();

                foreach (var item in decks)
                {
                    ObservableDecks.Add(item);
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

        // Navigation Commands
        [RelayCommand]
        async Task NavigateToCreateDeckPage()
        {
            await Shell.Current.GoToAsync(nameof(CreateDeckPage));
        }

        [RelayCommand]
        static async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
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

    }
}
