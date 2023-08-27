using flash_card_app.ViewModels;

namespace flash_card_app.Views;

public partial class CreateCardDeckPage : ContentPage
{
	public CreateCardDeckPage(CreateCardDeckViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}