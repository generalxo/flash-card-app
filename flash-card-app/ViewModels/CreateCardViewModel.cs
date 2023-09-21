using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;

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

            bool success = false;

            try
            {
                IsBusy = true;

                var repo = await App.Context.GetRepository<FlashCardModel>();

                FlashCard.Question = FlashCard.Question.Replace("\n", " ").Replace("  ", " ").Trim();
                FlashCard.Answer = FlashCard.Answer.Replace("\n", " ").Replace("  ", " ").Trim();
                FlashCard.Title = FlashCard.Title.Replace("\n", " ").Replace("  ", " ").Trim();

                if (FlashCard.Title.Length > 0 && FlashCard.Question.Length > 0 && FlashCard.Answer.Length > 0 && Id != 0)
                {
                    success = true;
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
                    success = false;
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

                if (success is true)
                {
                    FlashCard.Title = string.Empty;
                    FlashCard.Question = string.Empty;
                    FlashCard.Answer = string.Empty;
                    FlashCard.DeckId = 0;

                    await Shell.Current.GoToAsync("..");
                }
            }
        }
    }
}
