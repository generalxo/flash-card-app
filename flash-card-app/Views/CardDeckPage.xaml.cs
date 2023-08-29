using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class CardDeckPage : ContentPage
{
	CardDeckViewModel _viewModel;
	public CardDeckPage(CardDeckViewModel viewModel)
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