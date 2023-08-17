using flash_card_app.Models;

namespace flash_card_app.Views;
/* -- Psudo Code --
 * Collection Page will have a btn to create a new collection and a list of collections with the collection title being displayed. 
 * Collection items when clicked will route to the ListCardsPage
 */
public partial class CollectionPage : ContentPage
{
    public CollectionPage()
    {
        InitializeComponent();
    }

    private void AddCollection_Clicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync(nameof(CreateCollectionPage));
        App.Context.AddNewPerson(CollectionName.Text);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void btnRefresh_Clicked(object sender, EventArgs e)
    {
        List<CollectionModel> collectionModels = App.Context.GetAllCollections();

        collectionList.ItemsSource = collectionModels;
    }
}