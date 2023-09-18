using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace flash_card_app.ViewModels
{
	[QueryProperty("Deck", "Deck")]
	public partial class CardsViewModel : BaseViewModel
	{
		private readonly Helpers.ErrorHandler errorHandler = new();
		public ObservableCollection<FlashCardModel> OFlashCardModel { get; } = new();



		[ObservableProperty]
		DeckModel deck;
		public CardsViewModel()
		{

		}

		//OnAppearing Commands
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
				await errorHandler.DisplayErrorMsgAsync(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}

		//Action Commands
		[RelayCommand]
		async Task DeleteDeck()
		{
			if (IsBusy is true)
				return;

			bool deleteDeck = false;

			try
			{
				IsBusy = true;

				deleteDeck = await Shell.Current.DisplayAlert("Delete Deck", "Obs! This will delete \n- This Deck \n- All Cards in this deck", "Yes", "No");

				Debug.WriteLine($"deleteDeck: {deleteDeck}");

				//Create logic to 1. Delete all cards in deck 2. Delete Deck
				var flashCardRepo = await App.Context.GetRepository<FlashCardModel>();
				var flashCards = await flashCardRepo.GetAll();
				List<FlashCardModel> deleteCards = flashCards.ToList();
				foreach (var item in deleteCards)
				{
					if (item.DeckId == Deck.Id)
					{
						await flashCardRepo.Delete(item.Id);
					}
				}
				var deckRepo = await App.Context.GetRepository<DeckModel>();
				await deckRepo.Delete(Deck.Id);

			}
			catch (Exception ex)
			{
				await errorHandler.DisplayErrorMsgAsync(ex);
			}
			finally
			{
				IsBusy = false;
				if (deleteDeck)
				{
					await Shell.Current.GoToAsync("..");
				}
			}
		}

		//Navigation Commands
		[RelayCommand]
		async Task NavigateToCreateCardPage()
		{
			await Shell.Current.GoToAsync($"{nameof(CreateCardPage)}?Id={Deck.Id}");
		}

		[RelayCommand]
		async Task NavigateToEditCardPage(FlashCardModel flashCard)
		{
			await Shell.Current.GoToAsync(nameof(EditCardPage), true,
				new Dictionary<string, object>
				{
					{"FlashCard", flashCard }
				});
		}

	}
}
