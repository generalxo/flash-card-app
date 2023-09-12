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
			IsBusy = true;

			try
			{
				if (IsBusy is true)
					return;



			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Edit Card Error", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}

	}
}
