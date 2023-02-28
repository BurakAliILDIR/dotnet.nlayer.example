using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTO;
using NLayer.Core.Entity;
using NLayer.Core.Repository;
using NLayer.Core.Service;
using NLayer.Core.UnitOfWork;

namespace NLayer.Service.Service
{
    public class ProductServiceWithDto<TDto> : ServiceWithDto<Product, TDto>, IProductServiceWithDto<TDto>
        where TDto : class
    {
        private readonly IProductRepository _repository;

        public ProductServiceWithDto(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper,
            IProductRepository productRepository) :
            base(repository, unitOfWork, mapper)
        {
            _repository = productRepository;
        }


        public async Task<List<ProductWithCategoryDTO>> GetProductWithCategory()
        {
            var productWithCategory = await _repository.GetProductWithCategory();

            var productWithCategoryDto = mapper.Map<List<ProductWithCategoryDTO>>(productWithCategory);

            return productWithCategoryDto;
        }
    }
}