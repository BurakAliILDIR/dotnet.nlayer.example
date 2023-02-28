using NLayer.Core.DTO;
using NLayer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Service
{
    public interface IProductServiceWithDto<TDto> : IServiceWithDto<Product, TDto> where TDto : class
    {
        Task<List<ProductWithCategoryDTO>> GetProductWithCategory();
    }
}
