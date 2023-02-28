using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTO;
using NLayer.Core.Entity;

namespace NLayer.API.Controllers
{
    public class CategoryWithDtoController : BaseController
    {
        private readonly IServiceWithDto<Category, CategoryDTO> _service;


        public CategoryWithDtoController(IServiceWithDto<Category, CategoryDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();

            return Ok(CustomResponseDTO<List<CategoryDTO>>.Success(products.ToList(), 200));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDTO category)
        {
            var categoryDto = await _service.AddAsync(category);

            return Ok(CustomResponseDTO<CategoryDTO>.Success(categoryDto, 201));
        }


    }
}