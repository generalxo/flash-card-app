using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class CreateDeckPage : ContentPage
{
	public CreateDeckPage(CreateDeckViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}