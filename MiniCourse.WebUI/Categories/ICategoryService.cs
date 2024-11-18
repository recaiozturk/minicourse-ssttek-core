using MiniCourse.WebUI.Categories.ViewModels;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResult<List<CategoryViewModel>>> GetCategoriesAsync();
        Task<ServiceResult<CategoryUpdateViewModel>> GetCategoryAsync(int categoryId);
        Task<ServiceResult> CreateCategoryAsync(CategoryCreateViewModel model);
        Task<ServiceResult> UpdateCategoryAsync(CategoryUpdateViewModel model);
        Task<ServiceResult> DeleteCategoryAsync(int categoryId);
    }
}
