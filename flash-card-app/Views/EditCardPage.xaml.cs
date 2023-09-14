using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class EditCardPage : ContentPage
{
    public EditCardPage(EditCardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}