using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Views;
using System.Collections.ObjectModel;

namespace flash_card_app.ViewModels
{
    public partial class SelectDeckViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler ErrorHandler;
        public ObservableCollection<DeckModel> ODecks { get; } = new();

        public SelectDeckViewModel()
        {

        }

        //OnAppearing Command
        [RelayCommand]
        async Task GetDecks()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                ODecks.Clear();

                var repo = await App.Context.GetRepository<DeckModel>();
                var collection = await repo.GetAll();
                List<DeckModel> deckModels = collection.ToList();

                foreach (var item in deckModels)
                {
                    ODecks.Add(item);
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

        //Action Command
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
