using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.DTO;
using NLayer.Core.Entity;

namespace NLayer.Core.Service
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCategoryDTO>> GetProductWithCategory();
    }
}