using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class SelectDeckPage : ContentPage
{
	private readonly SelectDeckViewModel ViewModel;
	public SelectDeckPage(SelectDeckViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		ViewModel = viewModel;
	}

	protected override void OnAppearing()
	{
		ViewModel.GetDecksCommand.Execute(null);
	}
}