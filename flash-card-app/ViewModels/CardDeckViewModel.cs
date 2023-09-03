using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace flash_card_app.ViewModels
{
    public partial class CardDeckViewModel : BaseViewModel
    {
        public ObservableCollection<CardDeckModel> OCardDeckModel { get; } = new();
        public CardDeckViewModel()
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

                OCardDeckModel.Clear();

                var repo = await App.Context.GetRepository<CardDeckModel>();
                var collection = await repo.GetAll();
                List<CardDeckModel> cardDecks = collection.ToList();

                foreach (var item in cardDecks)
                {
                    OCardDeckModel.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("GetCardDecksAsync Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task NavigateToCreateCardDeckPage()
        {
            await Shell.Current.GoToAsync(nameof(CreateCardDeckPage));
        }

        [RelayCommand]
        static async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
