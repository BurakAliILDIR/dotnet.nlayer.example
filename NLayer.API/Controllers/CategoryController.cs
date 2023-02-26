using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTO;
using NLayer.Core.Entity;
using NLayer.Core.Service;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int id)
        {
            var categoryWithProductsDto = await _service.GetSingleCategoryByIdWithProductsAsync(id);

            return Ok(CustomResponseDTO<CategoryWithProductsDTO>.Success(categoryWithProductsDto, 200));
        }
    }
}