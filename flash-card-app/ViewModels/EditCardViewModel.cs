using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;

namespace flash_card_app.ViewModels
{
    [QueryProperty("FlashCard", "FlashCard")]
    public partial class EditCardViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler errorHandler = new();

        [ObservableProperty]
        FlashCardModel flashCard;
        public EditCardViewModel()
        {
            flashCard = new FlashCardModel();
        }

        [RelayCommand]
        async Task EditCard()
        {
            if (IsBusy is true)
                return;

            bool succes = false;

            try
            {
                IsBusy = true;

                var repo = await App.Context.GetRepository<FlashCardModel>();

                FlashCard.Question = FlashCard.Question.Replace("\n", " ").Replace("  ", " ").Trim();
                FlashCard.Answer = FlashCard.Answer.Replace("\n", " ").Replace("  ", " ").Trim();
                FlashCard.Title = FlashCard.Title.Replace("\n", " ").Replace("  ", " ").Trim();

                if (FlashCard.Title.Length > 0 && FlashCard.Question.Length > 0 && FlashCard.Answer.Length > 0)
                {
                    FlashCard.Streak = 0;
                    await repo.Update(FlashCard);
                    succes = true;
                }
                else
                {
                    succes = false;
                    await Shell.Current.DisplayAlert("Edit Card Error", "Invalid input was given", "OK");
                }
            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;

                if (succes is true)
                {
                    await Shell.Current.GoToAsync("..");
                }
            }
        }

        [RelayCommand]
        async Task DeleteCard()
        {
            if (IsBusy is true)
                return;

            bool deleteCard = false;

            try
            {
                IsBusy = true;

                deleteCard = await Shell.Current.DisplayAlert("Delete Card", "Are you sure you want to delete this card?", "Yes", "No");

                if (deleteCard is true)
                {
                    var repo = await App.Context.GetRepository<FlashCardModel>();
                    await repo.Delete(FlashCard.Id);
                }
            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;

                if (deleteCard is true)
                {
                    await Shell.Current.GoToAsync("..");
                }
            }
        }

    }
}