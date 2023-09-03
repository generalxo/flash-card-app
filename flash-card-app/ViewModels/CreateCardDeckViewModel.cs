using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using System.Diagnostics;

namespace flash_card_app.ViewModels
{
    public partial class CreateCardDeckViewModel : BaseViewModel
    {
        [ObservableProperty]
        string cardDeckName;
        public CreateCardDeckViewModel()
        {
            Title = "Create a Deck";
        }

        [RelayCommand]
        async Task CreateNewCardDeck()
        {
            var repo = await App.Context.GetRepository<CardDeckModel>();
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                if (CardDeckName.Length > 0)
                {
                    await repo.Add(new CardDeckModel { Name = CardDeckName });
                }
                else
                {
                    await Shell.Current.DisplayAlert("Create Deck Error", "Invalid input was given", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Create Deck Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                CardDeckName = string.Empty;
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task GoBackAsync()
        {
            CardDeckName = string.Empty;
            await Shell.Current.GoToAsync("..");
        }
    }
}
