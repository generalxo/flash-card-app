using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using flash_card_app.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace flash_card_app.ViewModels
{
    public partial class CollectionViewModel : BaseViewModel
    {
        DbContext dbContext;
        public ObservableCollection<CollectionModel> CollectionModels { get; } = new();

        public CollectionViewModel(DbContext dbContext)
        {
            Title = "Collections";
            this.dbContext = dbContext;
        }

        [RelayCommand]
        public void GetCollectoins()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var collection = dbContext.GetAllCollections();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
