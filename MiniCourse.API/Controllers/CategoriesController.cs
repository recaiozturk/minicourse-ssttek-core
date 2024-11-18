using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Categories;
using MiniCourse.Service.Categories.DTOs;

namespace MiniCourse.API.Controllers
{
    public class CategoriesController(ICategoryService categoryService) : CustomControllerBase
    {
        [HttpGet("getcategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var result = await categoryService.GetCategoriesAsync();
            return CreateObjectResult(result);
        }

        [HttpGet("getcategory")]
        public async Task<IActionResult> GetCategoryAsync(int categoryId)
        {
            var result = await categoryService.GetCategoryAsync(categoryId);
            return CreateObjectResult(result);
        }

        [HttpPost("createcategory")]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var result = await categoryService.CreateCategoryAsync(request);
            return CreateObjectResult(result);
        }

        [HttpPut("updatecategory")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            var result = await categoryService.UpdateCategoryAsync(request);
            return CreateObjectResult(result);
        }

        [HttpDelete("deletecategory")]
        public async Task<IActionResult> DeleteCategoryAsync(int categoryId)
        {
            var result = await categoryService.DeleteCategoryAsync(categoryId);
            return CreateObjectResult(result);
        }
    }
}
