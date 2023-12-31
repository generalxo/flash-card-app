using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class CreateCardPage : ContentPage
{
    public CreateCardPage(CreateCardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}