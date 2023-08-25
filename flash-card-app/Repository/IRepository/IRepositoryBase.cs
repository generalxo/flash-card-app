using System.Linq.Expressions;

namespace flash_card_app.Repository.IRepository
{
	public interface IRepositoryBase<T>
	{
		Task<IQueryable<T>> GetAll();
		Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> expression);
		Task<T> Add(T entity);
		Task<T> Update(T entity);
		Task<T> Delete(int id);
	}
}
