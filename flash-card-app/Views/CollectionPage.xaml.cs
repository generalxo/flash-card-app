using flash_card_app.ViewModels;

namespace flash_card_app.Views;
public partial class CollectionPage : ContentPage
{
	CollectionViewModel _viewModel;
	public CollectionPage(CollectionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.GetCollectionsCommand.Execute(null);
	}

}