namespace flash_card_app.Views;

public partial class EditCardsPage : ContentPage
{
    public EditCardsPage()
    {
        InitializeComponent();
    }

    private void btnFlashCard_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}