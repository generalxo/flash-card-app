using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using System.Diagnostics;

namespace flash_card_app.ViewModels
{
	[QueryProperty("Id", "Id")]
	public partial class CreateCardViewModel : BaseViewModel
	{
		[ObservableProperty]
		FlashCardModel flashCard;

		[ObservableProperty]
		int id;

		public CreateCardViewModel()
		{
			Title = "Create a Card";
			FlashCard = new FlashCardModel();
		}


		[RelayCommand]
		async Task CreateNewFlashCard() //This will be executed when save btn is clicked
		{
			var repo = await App.Context.GetRepository<FlashCardModel>();

			//Debug.WriteLine($"Title: {FlashCardModel.Title} Question: {FlashCardModel.Question} Answer: {FlashCardModel.Answer} Id: {Id}");

			if (IsBusy)
				return;

			try
			{
				IsBusy = true;


				if (FlashCard.Title.Length > 0 && FlashCard.Question.Length > 0 && FlashCard.Answer.Length > 0 && Id != 0)
				{
					await repo.Add(new FlashCardModel
					{
						Title = FlashCard.Title,
						Question = FlashCard.Question,
						Answer = FlashCard.Answer,
						DeckId = Id,
						Streak = 0
					});

				}
				else
				{
					await Shell.Current.DisplayAlert("Create Card Error", "Invalid input was given", "OK");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				await Shell.Current.DisplayAlert("Create Card Error", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
				FlashCard.Title = string.Empty;
				FlashCard.Question = string.Empty;
				FlashCard.Answer = string.Empty;
				FlashCard.DeckId = 0;

				await Shell.Current.GoToAsync("..");
			}
		}
	}
}
