using flash_card_app.Models;

namespace flash_card_app.Views;
public partial class CollectionPage : ContentPage
{
	private List<CollectionModel> collectionModels = new();
	public CollectionPage()
	{
		InitializeComponent();
	}

	private async void AddCollection_Clicked(object sender, EventArgs e)
	{
		//Shell.Current.GoToAsync(nameof(CreateCollectionPage));
		await App.Context.AddNewCollection(CollectionName.Text);
	}

	private void btnCancel_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}


	private async void btnRefresh_Clicked(object sender, EventArgs e)
	{
		collectionModels.Clear();
		var collections = await App.Context.GetAllCollections();

		collectionModels = collections.ToList();

		collectionList.ItemsSource = collectionModels;
	}
}