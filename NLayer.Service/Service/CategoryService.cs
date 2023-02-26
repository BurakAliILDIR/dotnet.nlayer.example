using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayer.Core.DTO;
using NLayer.Core.Entity;
using NLayer.Core.Repository;
using NLayer.Core.Service;
using NLayer.Core.UnitOfWork;

namespace NLayer.Service.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryWithProductsDTO> GetSingleCategoryByIdWithProductsAsync(int id)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(id);

            var categoryDTO = _mapper.Map<CategoryWithProductsDTO>(category);

            return categoryDTO;
        }
    }
}