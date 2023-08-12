namespace flash_card_app.Views;

public partial class AddCardPage : ContentPage
{
    public AddCardPage()
    {
        InitializeComponent();
    }

    private void btnAddCard_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}