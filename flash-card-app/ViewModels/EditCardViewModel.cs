﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;

namespace flash_card_app.ViewModels
{
    [QueryProperty("FlashCard", "FlashCard")]
    public partial class EditCardViewModel : BaseViewModel
    {
        private readonly Helpers.ErrorHandler errorHandler = new();

        [ObservableProperty]
        FlashCardModel flashCard;
        public EditCardViewModel()
        {
            flashCard = new FlashCardModel();
        }

        [RelayCommand]
        async Task EditCard()
        {
            if (IsBusy is true)
                return;

            try
            {
                IsBusy = true;
                //Debug.WriteLine($"Title: {FlashCard.Title} Question: {FlashCard.Question} Answer: {FlashCard.Answer} DeckId: {FlashCard.DeckId} ");

                var repo = await App.Context.GetRepository<FlashCardModel>();
                await repo.Update(FlashCard);

            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task DeleteCard()
        {
            if (IsBusy is true)
                return;

            bool deleteCard = false;

            try
            {
                IsBusy = true;

                deleteCard = await Shell.Current.DisplayAlert("Delete Card", "Are you sure you want to delete this card?", "Yes", "No");

                if (deleteCard is true)
                {
                    var repo = await App.Context.GetRepository<FlashCardModel>();
                    await repo.Delete(FlashCard.Id);
                    deleteCard = true;
                }
                else
                {
                    //Nothing should happen here
                }

            }
            catch (Exception ex)
            {
                await errorHandler.DisplayErrorMsgAsync(ex);
            }
            finally
            {
                IsBusy = false;

                if (deleteCard is true)
                {
                    await Shell.Current.GoToAsync("..");
                }
            }
        }

    }
}