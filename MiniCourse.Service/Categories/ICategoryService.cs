using MiniCourse.Service.Categories.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Categories
{
    public interface ICategoryService
    {
        Task<ApiServiceResult<List<CategoryResponse>>> GetCategoriesAsync();
        Task<ApiServiceResult<CategoryResponse>> GetCategoryAsync(int categoryId);
        Task<ApiServiceResult<CreateCategoryResponse>> CreateCategoryAsync(CreateCategoryRequest request);
        Task<ApiServiceResult> UpdateCategoryAsync(UpdateCategoryRequest request);
        Task<ApiServiceResult> DeleteCategoryAsync(int categoryId);
    }
}
