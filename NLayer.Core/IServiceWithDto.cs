using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Entity;

namespace NLayer.Core
{
    public interface IServiceWithDto<TEntity, TDto> where TEntity : BaseEntity where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();

        Task<TDto> FindByIdAsync(int id);

        Task<IEnumerable<TDto>> Where(Expression<Func<TEntity, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);

        Task<TDto> AddAsync(TDto dto);

        Task<IEnumerable<TDto>> AddRangeAsync(IEnumerable<TDto> dtoList);

        Task UpdateAsync(TDto dto);

        Task DeleteAsync(int id);

        Task DeleteRangeAsync(IEnumerable<int> ids);
    }
}