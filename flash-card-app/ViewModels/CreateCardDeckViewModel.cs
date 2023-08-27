using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;

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
			//Acces x:Name="CardDeckNameEntry" here
		}

		[RelayCommand]
		public async Task GoBackAsync()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}
