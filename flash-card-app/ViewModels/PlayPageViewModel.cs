using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace flash_card_app.ViewModels
{
    [QueryProperty("Deck", "Deck")]
    public partial class PlayPageViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler errorHandler = new();
        public ObservableCollection<FlashCardModel> OFlashCardModel { get; } = new();

        [ObservableProperty]
        DeckModel deck;

        [ObservableProperty]
        FlashCardModel flashcard;

        [ObservableProperty]
        string input;

        private int index;
        private int max;

        public PlayPageViewModel()
        {

        }

        // OnNavigatedTo Command
        [RelayCommand]
        async Task GetCards()
        {
            if (IsBusy)
                return;

            index = 0;

            try
            {
                IsBusy = true;

                var repo = await App.Context.GetRepository<FlashCardModel>();
                var collection = await repo.GetByCondition(x => x.DeckId == Deck.Id);
                List<FlashCardModel> flashCards = collection.OrderBy(x => x.Streak).ToList();
                //List<FlashCardModel> flashCards = collection.ToList();

                foreach (var item in flashCards)
                {
                    OFlashCardModel.Add(item);
                    //Debug.WriteLine(item);
                }

                max = flashCards.Count - 1;

            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                Flashcard = OFlashCardModel[index];
                IsBusy = false;
            }
        }

        // Action Command
        [RelayCommand]
        async Task EnterAnswer()
        { //Execute when enter btn is pressed
            int tempStreak;

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var repo = await App.Context.GetRepository<FlashCardModel>();

                tempStreak = OFlashCardModel[index].Streak;

                if (OFlashCardModel[index].Answer == Input)
                {
                    tempStreak++;
                    OFlashCardModel[index].Streak = tempStreak;
                    await repo.Update(OFlashCardModel[index]);
                }
                else
                {
                    OFlashCardModel[index].Streak = 0;
                    await repo.Update(OFlashCardModel[index]);
                }

            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;


                if (index == max)
                {
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    Debug.WriteLine($"FlashCard Answer: {OFlashCardModel[index].Answer} Input: {Input}");
                    Debug.WriteLine($"streak {OFlashCardModel[index].Streak}");
                    Input = string.Empty;
                    index++;
                    Flashcard = OFlashCardModel[index];
                }
            }
        }
    }

}
