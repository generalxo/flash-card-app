using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class CardsPage : ContentPage
{
    public CardsPage(CardsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}