using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Views;
using System.Collections.ObjectModel;

namespace flash_card_app.ViewModels
{
    [QueryProperty("Deck", "Deck")]
    public partial class CardsViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler errorHandler = new();
        public ObservableCollection<FlashCardModel> OFlashCardModel { get; } = new();

        [ObservableProperty]
        DeckModel deck;
        public CardsViewModel()
        {

        }

        [RelayCommand]
        async Task GetCards()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                OFlashCardModel.Clear();
                var repo = await App.Context.GetRepository<FlashCardModel>();
                var collection = await repo.GetByCondition(x => x.DeckId == Deck.Id);
                List<FlashCardModel> flashCards = collection.ToList();

                foreach (var item in flashCards)
                {
                    OFlashCardModel.Add(item);
                    //Debug.WriteLine($"Title: {item.Title}, DeckId: {item.DeckId}");
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
        async Task NavigateToCreateCardPage()
        {
            await Shell.Current.GoToAsync($"{nameof(CreateCardPage)}?Id={Deck.Id}");
        }

        [RelayCommand]
        async Task NavigateToEditCardPage(FlashCardModel flashCard)
        {
            await Shell.Current.GoToAsync(nameof(EditCardPage), true,
                new Dictionary<string, object>
                {
                    {"FlashCard", flashCard }
                });
        }

    }
}
