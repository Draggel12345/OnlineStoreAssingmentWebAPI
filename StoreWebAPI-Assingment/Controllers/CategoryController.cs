﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI_Assingment.Keys;
using StoreWebAPI_Assingment.Models.Category;
using StoreWebAPI_Assingment.Services;

namespace StoreWebAPI_Assingment.Controllers
{
    [Route("api/[controller]")]
    [UseApiKey]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequest request)
        {
            var category = await _service.CreateCategoryAsync(request);
            if (category != null)
            {
                return new OkObjectResult(category);
            }

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return new OkObjectResult(await _service.GetCategoriesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _service.GetCategoryAsync(id);
            if (category != null)
            {
                return new OkObjectResult(category);
            }

            return new NotFoundResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryRequest request)
        {
            var category = await _service.UpdateCategoryAsync(id, request);
            if (category != null)
            {
                return new OkObjectResult(category);
            }

            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            if (await _service.DeleteCategoryAsync(id))
            {
                return new OkResult();
            }

            return new BadRequestResult();
        }
    }
}
