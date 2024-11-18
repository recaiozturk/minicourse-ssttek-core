using MiniCourse.Repository.Categories;
using MiniCourse.Repository.Shared;
using MiniCourse.Service.Categories.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Categories
{
    public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) :ICategoryService
    {
        public async Task<ApiServiceResult<List<CategoryResponse>>> GetCategoriesAsync()
        {
            var categories =  categoryRepository.GetAll();

            var categoryResponses = categories.Select(category => new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();

            return ApiServiceResult<List<CategoryResponse>>.Success(categoryResponses, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<CategoryResponse>> GetCategoryAsync(int categoryId)
        {
            var category = await categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                return ApiServiceResult<CategoryResponse>.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
            }

            var categoryResponse = new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };

            return ApiServiceResult<CategoryResponse>.Success(categoryResponse, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<CreateCategoryResponse>> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name
            };

            await categoryRepository.AddAsync(category);
            await unitOfWork.CommitAsync();

            var response = new CreateCategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };

            return ApiServiceResult<CreateCategoryResponse>.Success(response, HttpStatusCode.Created);
        }

        public async Task<ApiServiceResult> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return ApiServiceResult.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
            }

            category.Name = request.Name;

            categoryRepository.Update(category);
            await unitOfWork.CommitAsync();

            return ApiServiceResult.Success(HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult> DeleteCategoryAsync(int categoryId)
        {
            var category = await categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                return ApiServiceResult.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
            }

            categoryRepository.Remove(category);
            await unitOfWork.CommitAsync();

            return ApiServiceResult.Success(HttpStatusCode.OK);
        }
    }
}
