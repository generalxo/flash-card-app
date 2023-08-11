namespace flash_card_app.Views;

public partial class AddCardPage : ContentPage
{
    public AddCardPage()
    {
        InitializeComponent();
    }

    private void btnFlashCard_Clicked(object sender, EventArgs e) //HomeBtn Needs to be renamed
    {
        Shell.Current.GoToAsync("..");
    }

    private void btnAddCard_Clicked(object sender, EventArgs e)
    {

    }
}