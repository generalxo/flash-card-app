using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;

/* To Do
 * Make sure there are no double blank spaces in question and answer or new lines / "\n" 
 */

namespace flash_card_app.ViewModels
{
    [QueryProperty("Id", "Id")]
    public partial class CreateCardViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler errorHandler = new();

        [ObservableProperty]
        FlashCardModel flashCard;

        [ObservableProperty]
        int id;

        public CreateCardViewModel()
        {
            Title = "Create a Card";
            FlashCard = new FlashCardModel();
        }

        // Action Commands
        [RelayCommand]
        async Task CreateNewFlashCard()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var repo = await App.Context.GetRepository<FlashCardModel>();

                if (FlashCard.Title.Length > 0 && FlashCard.Question.Length > 0 && FlashCard.Answer.Length > 0 && Id != 0)
                {
                    await repo.Add(new FlashCardModel
                    {
                        Title = FlashCard.Title,
                        Question = FlashCard.Question,
                        Answer = FlashCard.Answer,
                        DeckId = Id,
                        Streak = 0
                    });
                }
                else
                {
                    await Shell.Current.DisplayAlert("Create Card Error", "Invalid input was given", "OK");
                }
            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;
                FlashCard.Title = string.Empty;
                FlashCard.Question = string.Empty;
                FlashCard.Answer = string.Empty;
                FlashCard.DeckId = 0;

                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
