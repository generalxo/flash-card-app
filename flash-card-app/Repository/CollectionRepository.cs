using flash_card_app.Models;
using flash_card_app.Repository.IRepository;
using SQLite;

namespace flash_card_app.Repository
{
	public class CollectionRepository : RepositoryBase<CollectionModel>, ICollectionRepository
	{
		public CollectionRepository(SQLiteAsyncConnection conn) : base(conn)
		{
		}
	}
}
