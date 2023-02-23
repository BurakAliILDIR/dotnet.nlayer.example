using System.Linq.Expressions;

namespace NLayer.Core.Service
{
    interface IService<T> where T : class
    {

        // IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
