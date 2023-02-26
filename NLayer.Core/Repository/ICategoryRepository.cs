using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Entity;

namespace NLayer.Core.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> GetSingleCategoryByIdWithProductsAsync(int id);
    }
}