using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core.DTO;
using NLayer.Core.Entity;
using NLayer.Core.Repository;
using NLayer.Core.Service;
using NLayer.Core.UnitOfWork;
using NLayer.Service.Exception;

namespace NLayer.Caching
{
    public class ProductServiceWithCache : IProductService
    {
        private const string ProductCacheKey = "cache-products";

        private readonly Mapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;


        public ProductServiceWithCache(Mapper mapper, IMemoryCache memoryCache, IProductRepository repository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            //if (!_memoryCache.TryGetValue(ProductCacheKey, _))
            //{
            //    _memoryCache.Set(ProductCacheKey, repository.GetAll().ToList());
            //}
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(ProductCacheKey));
        }

        public Task<Product> FindByIdAsync(int id)
        {
            var product = _memoryCache.Get<List<Product>>(ProductCacheKey).FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new NotFoundException("Product not found.");
            }

            return Task.FromResult(product);
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(ProductCacheKey).Where(expression.Compile()).AsQueryable();
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();

            return entities;
        }

        public async Task UpdateAsync(Product entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<Product> entities)
        {
            _repository.DeleteRange(entities);
            await CacheAllProductsAsync();
        }

        public async Task<List<ProductWithCategoryDTO>> GetProductWithCategory()
        {
            var productWithCategory = await _repository.GetProductWithCategory();

            var productWithCategoryDto = _mapper.Map<List<ProductWithCategoryDTO>>(productWithCategory);

            return productWithCategoryDto;
        }


        public async Task CacheAllProductsAsync()
        {
            _ = _memoryCache.Set(ProductCacheKey, _repository.GetAll().ToListAsync());
        }
    }
}