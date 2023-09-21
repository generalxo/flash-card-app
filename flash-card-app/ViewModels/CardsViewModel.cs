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
        public ObservableCollection<FlashCardModel> ObservableFlashCards { get; } = new();

        [ObservableProperty]
        DeckModel deck;
        public CardsViewModel()
        {

        }

        //OnAppearing Commands
        [RelayCommand]
        async Task GetCards()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var repo = await App.Context.GetRepository<FlashCardModel>();

                ObservableFlashCards.Clear();

                var collection = await repo.GetByCondition(x => x.DeckId == Deck.Id);
                List<FlashCardModel> flashCards = collection.ToList();

                foreach (var card in flashCards)
                {
                    ObservableFlashCards.Add(card);
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

        //Action Commands
        [RelayCommand]
        async Task DeleteDeck()
        {
            if (IsBusy is true)
                return;

            bool deleteDeck = false; //Confirmation to delete deck, no/false by default.

            try
            {
                IsBusy = true;

                deleteDeck = await Shell.Current.DisplayAlert("Delete Deck", "Obs! This will delete \n- This Deck \n- All Cards in this deck", "Yes", "No");
                //Debug.WriteLine($"Delete Deck bool: {deleteDeck}");

                if (deleteDeck is true)
                {
                    var flashCardRepo = await App.Context.GetRepository<FlashCardModel>();
                    var deckRepo = await App.Context.GetRepository<DeckModel>();

                    var flashCards = await flashCardRepo.GetByCondition(x => x.DeckId == Deck.Id);
                    List<FlashCardModel> deleteCards = flashCards.ToList();

                    foreach (var card in deleteCards)
                    {
                        await flashCardRepo.Delete(card.Id);
                    }

                    await deckRepo.Delete(Deck.Id);
                }
            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;

                if (deleteDeck)
                {
                    await Shell.Current.GoToAsync("..");
                }
            }
        }

        //Navigation Commands
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
