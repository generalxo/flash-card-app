using flash_card_app.Repository.IRepository;
using SQLite;
using System.Linq.Expressions;

namespace flash_card_app.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly SQLiteAsyncConnection _conn;

        public Repository(SQLiteAsyncConnection conn)
        {
            _conn = conn;
        }

        public async Task<IQueryable<T>> GetAll()
        {
            try
            {
                var items = await _conn.Table<T>().ToListAsync();
                return items.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve data. {ex.Message}");
            }
        }

        public async Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            try
            {
                var items = await _conn.Table<T>().ToListAsync();
                return items.AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve data. {ex.Message}");
            }
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                await _conn.InsertAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add entity. Error: {ex.Message}");
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                await _conn.UpdateAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update entity. Error: {ex.Message}");
            }
        }

        public async Task<T> Delete(int id)
        {
            try
            {
                var entity = await _conn.FindAsync<T>(id);
                if (entity != null)
                {
                    await _conn.DeleteAsync(entity);
                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete entity. Error: {ex.Message}");
            }
        }
    }
}

