using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using System.Diagnostics;

namespace flash_card_app.ViewModels
{
	public partial class CreateDeckViewModel : BaseViewModel
	{
		[ObservableProperty]
		string deckName;
		public CreateDeckViewModel()
		{
			Title = "Create a Deck";
		}

		[RelayCommand]
		async Task CreateNewDeck()
		{
			var repo = await App.Context.GetRepository<DeckModel>();
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				if (DeckName.Length > 0)
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
				Debug.WriteLine(ex.Message);
				await Shell.Current.DisplayAlert("Create Deck Error", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
				DeckName = string.Empty;
				await Shell.Current.GoToAsync("..");
			}
		}

		[RelayCommand]
		async Task GoBackAsync()
		{
			DeckName = string.Empty;
			await Shell.Current.GoToAsync("..");
		}
	}
}
