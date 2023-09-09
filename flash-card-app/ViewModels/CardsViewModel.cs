﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace flash_card_app.ViewModels
{
    [QueryProperty("CardDeck", "CardDeck")]
    public partial class CardsViewModel : BaseViewModel
    {
        public ObservableCollection<FlashCardModel> OFlashCardModel { get; } = new();

        [ObservableProperty]
        CardDeckModel cardDeck;
        public CardsViewModel()
        {

        }

        //This code has mostly not been implemented or tested yet

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
                var collection = await repo.GetByCondition(x => x.CardDeckId == CardDeck.Id);
                List<FlashCardModel> flashCards = collection.ToList();

                foreach (var item in flashCards)
                {
                    OFlashCardModel.Add(item);
                    Debug.WriteLine($"Title: {item.Title}, CardDeckId: {item.CardDeckId}");
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
            await Shell.Current.GoToAsync($"{nameof(CreateCardPage)}?Id={CardDeck.Id}");
        }

    }
}
