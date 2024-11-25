using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MiniCourse.WebUI.Categories.DTOs;
using MiniCourse.WebUI.Categories.ViewModels;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.Categories
{
    public class CategoryService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) : ICategoryService
    {
        public async Task<ServiceResult<CategoryUpdateViewModel>> GetCategoryAsync(int categoryId)
        {
            var address = $"/api/Categories/get-category?categoryId={categoryId}";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<CategoryUpdateViewModel>.Fail(problemDetail!.Detail!);
            }

            var category = await response.Content.ReadFromJsonAsync<CategoryResponse>();

            var categoryViewModel = new CategoryUpdateViewModel
            {
                Name = category.Name,
                Id = category.Id
            };

            return ServiceResult<CategoryUpdateViewModel>.Success(categoryViewModel);
        }

        public async Task<ServiceResult<List<CategoryViewModel>>> GetCategoriesAsync()
        {
            var address = "/api/Categories/get-categories";
            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<List<CategoryViewModel>>.Fail(problemDetail!.Detail!);
            }

            var categories = await response.Content.ReadFromJsonAsync<List<CategoryViewModel>>();

            return ServiceResult<List<CategoryViewModel>>.Success(categories ?? new List<CategoryViewModel>());
        }

        public async Task<ServiceResult> CreateCategoryAsync(CategoryCreateViewModel model)
        {
            var address = "/api/Categories/create-category";

            var response = await client.PostAsJsonAsync(address, model);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var categoryResponse = await response.Content.ReadFromJsonAsync<CategoryCreateResponse>();

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $"'{categoryResponse!.Name}' kategorisi başarıyla oluşturuldu.";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> UpdateCategoryAsync(CategoryUpdateViewModel model)
        {
            var address = "/api/Categories/update-category";

            var response = await client.PutAsJsonAsync(address, model);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = "Kategori başarıyla güncellendi.";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteCategoryAsync(int categoryId)
        {
            var address = $"/api/Categories/delete-category?categoryId={categoryId}";

            var response = await client.DeleteAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = "Kategori başarıyla silindi.";

            return ServiceResult.Success();
        }
    }
}
