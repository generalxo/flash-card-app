namespace flash_card_app.Views;

public partial class FlashCardPage : ContentPage
{
    public FlashCardPage()
    {
        InitializeComponent();
    }

    private void btnAddCard_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddCardPage));
    }

    private void btnEditCard_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditCardsPage));
    }
}