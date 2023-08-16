namespace flash_card_app.Views;

public partial class CreateCollectionPage : ContentPage
{
    public CreateCollectionPage()
    {
        InitializeComponent();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void btnSaveCollection_Clicked(object sender, EventArgs e)
    {
        //More Will Go Here for now just routing back to CollectionPage
        Shell.Current.GoToAsync("..");
    }
}