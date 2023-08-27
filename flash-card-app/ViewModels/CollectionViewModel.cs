using CommunityToolkit.Mvvm.Input;
using flash_card_app.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace flash_card_app.ViewModels
{
	public partial class CollectionViewModel : BaseViewModel
	{
		public ObservableCollection<CollectionModel> OCollectionModel { get; } = new();

		public CollectionViewModel()
		{
			Title = "Collections";
		}

		[RelayCommand]
		async Task GetCollectionsAsync()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;

				OCollectionModel.Clear();

				var repo = await App.Context.GetRepository<CollectionModel>();
				var collections = await repo.GetAll();

				foreach (var item in collections)
				{
					OCollectionModel.Add(item);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				await Shell.Current.DisplayAlert("GetCollectionsAsync Error", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}

		}

		[RelayCommand]
		async Task GoBackAsync()
		{
			await Shell.Current.GoToAsync("..");
		}

	}
}
