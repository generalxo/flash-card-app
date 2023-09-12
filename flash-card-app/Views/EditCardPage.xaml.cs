using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class EditCardPage : ContentPage
{
	private readonly EditCardViewModel _viewModel;
	public EditCardPage(EditCardViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
	}
	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}

}