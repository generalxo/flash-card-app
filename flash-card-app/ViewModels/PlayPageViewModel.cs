using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using System.Collections.ObjectModel;

/* To Do
 * Inform user if answer given was correct or not
 * Make it so upercase does not matter when checking answer.
 */

namespace flash_card_app.ViewModels
{
    [QueryProperty("Deck", "Deck")]
    public partial class PlayPageViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler errorHandler = new();
        public ObservableCollection<FlashCardModel> ObservableFlashCards { get; } = new();

        [ObservableProperty]
        DeckModel deck;

        [ObservableProperty]
        FlashCardModel flashcard;

        [ObservableProperty]
        string input;

        private int index;
        private int ammountOfCardsInDeck;

        public PlayPageViewModel()
        {

        }

        // OnNavigatedTo Command
        [RelayCommand]
        async Task GetCards()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                index = 0;

                var repo = await App.Context.GetRepository<FlashCardModel>();
                var collection = await repo.GetByCondition(x => x.DeckId == Deck.Id);
                List<FlashCardModel> flashCards = collection.OrderBy(x => x.Streak).ToList();

                foreach (var item in flashCards)
                {
                    ObservableFlashCards.Add(item);
                }

                ammountOfCardsInDeck = flashCards.Count - 1;
            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                Flashcard = ObservableFlashCards[index];
                IsBusy = false;
            }
        }

        // Action Command
        [RelayCommand]
        async Task EnterAnswer()
        {
            if (IsBusy)
                return;

            int streakValue;

            try
            {
                IsBusy = true;

                var repo = await App.Context.GetRepository<FlashCardModel>();

                streakValue = ObservableFlashCards[index].Streak;

                if (ObservableFlashCards[index].Answer == Input)
                {
                    streakValue++;
                    ObservableFlashCards[index].Streak = streakValue;
                    await repo.Update(ObservableFlashCards[index]);
                }
                else
                {
                    ObservableFlashCards[index].Streak = 0;
                    await repo.Update(ObservableFlashCards[index]);
                }
            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;

                if (index == ammountOfCardsInDeck)
                {
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    Input = string.Empty;
                    index++;
                    Flashcard = ObservableFlashCards[index];
                }
            }
        }
    }

}
