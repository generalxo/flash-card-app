using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class DeckPage : ContentPage
{
	private readonly DeckViewModel _viewModel;
	public DeckPage(DeckViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
	}

	protected override void OnAppearing()
	{
		_viewModel.GetCardDecksCommand.Execute(null);
	}
}