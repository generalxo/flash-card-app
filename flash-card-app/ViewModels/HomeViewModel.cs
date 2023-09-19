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

		// Navigation Commands
		[RelayCommand]
		async Task NavigateToDeckPage()
		{
			await Shell.Current.GoToAsync(nameof(DeckPage));
		}

		[RelayCommand]
		async Task NavigateToSelectDeckPage()
		{
			await Shell.Current.GoToAsync(nameof(SelectDeckPage));
		}

		// Action Commnads
		[RelayCommand]
		static void ExitApp()
		{
			System.Environment.Exit(0);
		}
	}
}
