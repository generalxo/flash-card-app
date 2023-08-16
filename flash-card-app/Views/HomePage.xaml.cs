namespace flash_card_app.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void btnCollections_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CollectionPage));
    }

    private void btnStart_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FlashCardPage));
    }

    private void btnExit_Clicked(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }
}