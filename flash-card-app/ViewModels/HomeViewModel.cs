using CommunityToolkit.Mvvm.Input;
using flash_card_app.Views;

namespace flash_card_app.ViewModels
{
	public partial class HomeViewModel : BaseViewModel
	{
		public HomeViewModel()
		{
			Title = "Home";
		}

		[RelayCommand]
		async Task NavigateToCardDeckPage()
		{
			await Shell.Current.GoToAsync(nameof(CardDeckPage));
		}

		[RelayCommand]
		async Task NavigateToCollectionPage()
		{
			await Shell.Current.GoToAsync(nameof(CollectionPage));
		}

		[RelayCommand]
		void ExitApp()
		{
			System.Environment.Exit(0);
		}
	}
}
