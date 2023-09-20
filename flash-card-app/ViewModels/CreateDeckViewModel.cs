using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;

namespace flash_card_app.ViewModels
{
    public partial class CreateDeckViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler errorHandler = new();

        [ObservableProperty]
        string deckName;
        public CreateDeckViewModel()
        {
            Title = "Create a Deck";
        }

        //Action Command
        [RelayCommand]
        async Task CreateNewDeck()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var repo = await App.Context.GetRepository<DeckModel>();

                if (DeckName.Length > 0 && DeckName is not null)
                {
                    await repo.Add(new DeckModel { Name = DeckName });
                }
                else
                {
                    await Shell.Current.DisplayAlert("Create Deck Error", "Invalid input was given", "OK");
                }
            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;
                DeckName = string.Empty;
                await Shell.Current.GoToAsync("..");
            }
        }

        // Navigation Command
        [RelayCommand]
        async Task GoBackAsync()
        {
            DeckName = string.Empty;
            await Shell.Current.GoToAsync("..");
        }
    }
}
