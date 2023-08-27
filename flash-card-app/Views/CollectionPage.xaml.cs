using flash_card_app.Models;
using flash_card_app.ViewModels;

namespace flash_card_app.Views;
public partial class CollectionPage : ContentPage
{
	private List<CollectionModel> collectionModels = new();

	public CollectionPage(CollectionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		viewModel.GetCollectionsCommand.Execute(null);
	}

	private async void AddCollection_Clicked(object sender, EventArgs e)
	{
		//Shell.Current.GoToAsync(nameof(CreateCollectionPage));
		var collectionRepository = await App.Context.GetRepository<CollectionModel>();
		await collectionRepository.Add(new CollectionModel { Name = CollectionName.Text });
	}

}