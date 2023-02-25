using System.Linq.Expressions;

namespace NLayer.Core.Service
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> FindByIdAsync(int id);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        void UpdateAsync(T entity);

        void DeleteAsync(T entity);

        void DeleteRangeAsync(IEnumerable<T> entities);
    }
}