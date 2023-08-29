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
		public async Task CreateNewCardDeck()
		{
			var repo = await App.Context.GetRepository<CardDeckModel>();
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;

				await repo.Add(new CardDeckModel { Name = CardDeckName });

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				await Shell.Current.DisplayAlert("GetCollectionsAsync Error", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
				await Shell.Current.GoToAsync("..");
			}
		}

		[RelayCommand]
		public async Task GoBackAsync()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}
