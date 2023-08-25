using flash_card_app.Models;
using flash_card_app.Repository;
using flash_card_app.Repository.IRepository;
using SQLite;

namespace flash_card_app.Services
{
	public class DbContext
	{
		private SQLiteAsyncConnection _conn;
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
			// You can add more CreateTableAsync calls for other models
		}

		public async Task<IRepository<T>> GetRepository<T>() where T : class, new()
		{
			await Init();
			return new Repository<T>(_conn);
		}
	}
}
