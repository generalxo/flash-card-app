using flash_card_app.Models;

namespace flash_card_app.Views;

public partial class EditCardsPage : ContentPage
{
    public EditCardsPage()
    {
        InitializeComponent();

        //We want to get some CardModel here from a database, json file, etc. & then display it.
        //Implement some way to edit a card, delete a card, etc.

        List<FlashCardModel> flashCardList = new()
        {
            new FlashCardModel
            {
                Question = "What is the Earth's primary source of energy?",
                Answer = "The Sun"
            },
            new FlashCardModel
            {
                Question= "What is the capital of France?",
                Answer = "Paris"
            },
            new FlashCardModel
            {
                Question= "Who wrote the play: Romeo and Juliet",
                Answer = "William Shakespeare"
            }
        };



        listAddCard.ItemsSource = flashCardList;
    }

    private void btnFlashCard_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}