using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using System.Diagnostics;

namespace flash_card_app.ViewModels
{
    public partial class CreateCardViewModel : BaseViewModel
    {
        [ObservableProperty]
        FlashCardModel flashCardModel;
        public CreateCardViewModel()
        {
            Title = "Create a Card";
        }

        //This code has not been implemented or tested yet

        [RelayCommand]
        async Task CreateNewFlashCard() //This will be executed when save btn is clicked
        {
            var repo = await App.Context.GetRepository<FlashCardModel>();

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if (FlashCardModel.Title.Length > 0 && FlashCardModel.Question.Length > 0 && FlashCardModel.Answer.Length > 0 && FlashCardModel.CardDeckId != 0)
                {
                    await repo.Add(new FlashCardModel
                    {
                        Title = FlashCardModel.Title,
                        Question = FlashCardModel.Question,
                        Answer = FlashCardModel.Answer,
                        CardDeckId = FlashCardModel.CardDeckId
                    });
                }
                else
                {
                    await Shell.Current.DisplayAlert("Create Card Error", "Invalid input was given", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Create Card Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                FlashCardModel.Title = string.Empty;
                FlashCardModel.Question = string.Empty;
                FlashCardModel.Answer = string.Empty;
                FlashCardModel.CardDeckId = 0;

                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
