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

        [RelayCommand]
        async Task DeleteCard()
        {
            if (IsBusy is true)
                return;

            bool wasDeleted = false;

            try
            {
                IsBusy = true;

                bool result = await Shell.Current.DisplayAlert("Delete Card", "Are you sure you want to delete this card?", "Yes", "No");
                //Debug.WriteLine($"Result: {result}");
                if (result is true)
                {
                    var repo = await App.Context.GetRepository<FlashCardModel>();
                    await repo.Delete(FlashCard.Id);
                    wasDeleted = true;
                }
                else
                {
                    //Nothing should happen here
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Edit Card Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;

                if (wasDeleted is true)
                {
                    await Shell.Current.GoToAsync("..");
                }
            }
        }

    }
}
