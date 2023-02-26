using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.DTO;
using NLayer.Core.Entity;

namespace NLayer.Core.Service
{
    public interface ICategoryService : IService<Category>
    {
        Task<CategoryWithProductsDTO> GetSingleCategoryByIdWithProductsAsync(int id);


    }
}