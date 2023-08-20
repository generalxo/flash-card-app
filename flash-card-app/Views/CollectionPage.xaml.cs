using flash_card_app.Models;

namespace flash_card_app.Views;
public partial class CollectionPage : ContentPage
{
    public CollectionPage()
    {
        InitializeComponent();
    }

    private void AddCollection_Clicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync(nameof(CreateCollectionPage));
        App.Context.AddNewCollection(CollectionName.Text);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }


    private void btnRefresh_Clicked(object sender, EventArgs e)
    {
        List<CollectionModel> collectionModels = App.Context.GetAllCollections();

        collectionList.ItemsSource = collectionModels;
    }
}