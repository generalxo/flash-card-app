using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class CardsPage : ContentPage
{
    private readonly CardsViewModel _viewModel;
    public CardsPage(CardsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    protected override void OnAppearing()
    {
        _viewModel.GetCardsCommand.Execute(null);
    }
}