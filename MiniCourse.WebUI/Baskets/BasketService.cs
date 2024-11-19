using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MiniCourse.WebUI.Baskets.DTOs;
using MiniCourse.WebUI.Baskets.ViewModels;
using MiniCourse.WebUI.Categories.ViewModels;
using MiniCourse.WebUI.Shared;
using System.Security.Claims;

namespace MiniCourse.WebUI.Baskets
{
    public class BasketService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) :IBasketService
    {
        public async Task<ServiceResult<CustomJsonModel>> AddCourseToBasketAsync(int courseId, int quantity)
        {
            CustomJsonModel jsonModel = new CustomJsonModel();
            AddBasketModel addBasketModel= new AddBasketModel();

            addBasketModel.CourseId = courseId;
            addBasketModel.Quantity = quantity;

            var userId= httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId is null)
            {
                jsonModel.IsValid = false;
                jsonModel.Message = "Sepete Ekleme yapmak için giriş yapınız";
                return ServiceResult<CustomJsonModel>.Success(jsonModel);
            }

            addBasketModel.UserId = userId;

            var address = "/api/Baskets/add-to-basket";

            var response = await client.PostAsJsonAsync(address, addBasketModel);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                jsonModel.IsValid = false;
                jsonModel.Message= problemDetail!.Detail!;
                return ServiceResult<CustomJsonModel>.Success(jsonModel);
            }

            var addBasketResponse = await response.Content.ReadFromJsonAsync<AddedBasketResponse>();

            jsonModel.Message = "Kurs Sepete Eklendi";
            jsonModel.IsValid = true;
            jsonModel.Data= addBasketResponse;

            return ServiceResult<CustomJsonModel>.Success(jsonModel);
        }

        public async Task<ServiceResult<BasketResponse>> GetBasketByUserIdAsync()
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var address = $"/api/Baskets/get-basket?userId={userId}";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<BasketResponse>.Fail(problemDetail!.Detail!);
            }

            var basketResponse = await response.Content.ReadFromJsonAsync<BasketResponse>();

            return ServiceResult<BasketResponse>.Success(basketResponse);
        }

        public async Task<ServiceResult<BasketDetailViewModel>> GetBasketDetailAsync()
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId is null)
            {
                var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
                tempData["ErrorMessage"] = $"Sepetinizdce işlem yapabilmeniz için Lütfen giriş yapınız";
                return ServiceResult<BasketDetailViewModel>.Fail("");
            }
                
            var address = $"/api/Baskets/get-basket-detail?userId={userId}";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<BasketDetailViewModel>.Fail(problemDetail!.Detail!);
            }

            var basketDetailResponse = await response.Content.ReadFromJsonAsync<BasketDetailViewModel>();

            return ServiceResult<BasketDetailViewModel>.Success(basketDetailResponse);
        }

        public async Task<ServiceResult> RemoveItemFromBasketAsync(int courseId)
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var address = $"/api/Baskets/remove-from-basket?userId={userId}&courseId={courseId}";

            var response = await client.DeleteAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $"Ürün sepetten çıkarıldı";

            return ServiceResult.Success();
        }
    }
}
