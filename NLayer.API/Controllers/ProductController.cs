using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTO;
using NLayer.Core.Entity;
using NLayer.Core.Service;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> All()
        {
            var products = await _service.GetAllAsync();

            var productsDTO = _mapper.Map<List<ProductDTO>>(products.ToList());

            return Ok(CustomResponseDTO<List<ProductDTO>>.Success(productsDTO, 200));
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetProductWithCategory()
        {
            var products = await _service.GetProductWithCategory();

            return Ok(CustomResponseDTO<List<ProductWithCategoryDTO>>.Success(products, 200));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var product = await _service.FindByIdAsync(id);

            var productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(CustomResponseDTO<ProductDTO>.Success(productDTO, 200));
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);

            product = await _service.AddAsync(product);

            productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(CustomResponseDTO<ProductDTO>.Success(productDTO, 201));
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);

            await _service.UpdateAsync(product);

            return Ok(CustomResponseDTO<ProductDTO>.Success(null, 204));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var product = await _service.FindByIdAsync(id);

            await _service.DeleteAsync(product);

            return Ok(CustomResponseDTO<ProductDTO>.Success(null, 204));
        }
    }
}