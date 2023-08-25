using flash_card_app.Models;
using flash_card_app.Repository;
using SQLite;

namespace flash_card_app.Services
{
	public class DbContext
	{
		private SQLiteAsyncConnection _conn;
		private RepositoryBase<CollectionModel> _collectionRepository;
		string _dbPath;

		public string StatusMessage { get; set; }

		public DbContext(string dbPath)
		{
			_dbPath = dbPath;
		}

		private async Task Init()
		{
			if (_conn != null)
				return;

			_conn = new SQLiteAsyncConnection(_dbPath);
			await _conn.CreateTableAsync<CollectionModel>();
			_collectionRepository = new CollectionRepository(_conn);
		}

		public async Task AddNewCollection(string name)
		{
			await Init();
			await _collectionRepository.Add(new CollectionModel { Name = name });
			StatusMessage = $"Record added (Name: {name})";
		}

		public async Task<IQueryable<CollectionModel>> GetAllCollections()
		{
			await Init();
			return await _collectionRepository.GetAll();
		}
	}
}
