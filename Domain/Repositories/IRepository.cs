using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRepository : IDisposable
    {
    }

    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T?> GetAsync(int id);
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<List<T?>> GetListByFilterAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy = null, string orderByDescending = "ASC", int? take = null, params Expression<Func<T, object>>[] includes);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> expression);

    }
}
