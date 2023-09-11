using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

//Notes: Create a tapevent on a card that navigates to a edit card page

namespace flash_card_app.ViewModels
{
	[QueryProperty("Deck", "Deck")]
	public partial class CardsViewModel : BaseViewModel
	{
		public ObservableCollection<FlashCardModel> OFlashCardModel { get; } = new();

		[ObservableProperty]
		DeckModel deck;
		public CardsViewModel()
		{

		}

		[RelayCommand]
		async Task GetCards()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;

				OFlashCardModel.Clear();
				var repo = await App.Context.GetRepository<FlashCardModel>();
				var collection = await repo.GetByCondition(x => x.DeckId == Deck.Id);
				List<FlashCardModel> flashCards = collection.ToList();

				foreach (var item in flashCards)
				{
					OFlashCardModel.Add(item);
					//Debug.WriteLine($"Title: {item.Title}, DeckId: {item.DeckId}");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				await Shell.Current.DisplayAlert("GetFlashCardsAsync Error", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}

		[RelayCommand]
		async Task NavigateToCreateCardPage()
		{
			await Shell.Current.GoToAsync($"{nameof(CreateCardPage)}?Id={Deck.Id}");
		}

	}
}
