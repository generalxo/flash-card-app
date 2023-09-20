using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Views;
using System.Collections.ObjectModel;

namespace flash_card_app.ViewModels
{
    public partial class SelectDeckViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler ErrorHandler;
        public ObservableCollection<DeckModel> ObservableDecks { get; } = new();

        public SelectDeckViewModel()
        {

        }

        // OnAppearing Command
        [RelayCommand]
        async Task GetDecks()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                ObservableDecks.Clear();

                var repo = await App.Context.GetRepository<DeckModel>();
                var collection = await repo.GetAll();
                List<DeckModel> deckModels = collection.ToList();

                foreach (var item in deckModels)
                {
                    ObservableDecks.Add(item);
                }
            }
            catch (Exception ex)
            {
                await ErrorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Action Command
        [RelayCommand]
        async Task NavigateToPlayPage(DeckModel deckModel)
        {
            await Shell.Current.GoToAsync(nameof(PlayPage), true,
                new Dictionary<string, object>
                {
                    {"Deck", deckModel }
                });
        }
    }
}
