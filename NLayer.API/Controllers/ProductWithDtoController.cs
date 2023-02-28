using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filter;
using NLayer.Core.DTO;
using NLayer.Core.Entity;
using NLayer.Core.Service;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithDtoController : BaseController
    {
        private readonly IProductServiceWithDto<ProductDTO> _service;

        public ProductWithDtoController(IProductServiceWithDto<ProductDTO> productService)
        {
            _service = productService;
        }

        [HttpGet]
        public async Task<ActionResult> All()
        {
            var products = await _service.GetAllAsync();

            return Ok(CustomResponseDTO<List<ProductDTO>>.Success(products.ToList(), 200));
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetProductWithCategory()
        {
            var products = await _service.GetProductWithCategory();

            return Ok(CustomResponseDTO<List<ProductWithCategoryDTO>>.Success(products, 200));
        }

        [HttpGet("{id}")]
        [ServiceFilter(type: typeof(NotFoundFilter<Product>))]
        public async Task<ActionResult> FindById(int id)
        {
            var product = await _service.FindByIdAsync(id);

            return Ok(CustomResponseDTO<ProductDTO>.Success(product, 200));
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductDTO productDTO)
        {
            productDTO = await _service.AddAsync(productDTO);

            return Ok(CustomResponseDTO<ProductDTO>.Success(productDTO, 201));
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductDTO productDTO)
        {
            await _service.UpdateAsync(productDTO);

            return Ok(CustomResponseDTO<ProductDTO>.Success(productDTO, 204));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok(CustomResponseDTO<string>.Success("", 204));
        }
    }
}