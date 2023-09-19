using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class PlayPage : ContentPage
{
    private readonly PlayPageViewModel _viewModel;
    public PlayPage(PlayPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        _viewModel.GetCardsCommand.Execute(null);
    }

}