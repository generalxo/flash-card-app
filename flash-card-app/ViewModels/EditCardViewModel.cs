using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;

namespace flash_card_app.ViewModels
{
    [QueryProperty("FlashCard", "FlashCard")]
    public partial class EditCardViewModel : BaseViewModel
    {
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

            try
            {
                IsBusy = true;
                //Debug.WriteLine($"Title: {FlashCard.Title} Question: {FlashCard.Question} Answer: {FlashCard.Answer} DeckId: {FlashCard.DeckId} ");

                var repo = await App.Context.GetRepository<FlashCardModel>();
                await repo.Update(FlashCard);

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Edit Card Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                await Shell.Current.GoToAsync("..");
            }
        }

    }
}
