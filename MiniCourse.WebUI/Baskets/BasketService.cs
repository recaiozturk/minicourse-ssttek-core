using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Courses.DTOs;
using MiniCourse.WebUI.Courses.ViewModels;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.Util;
using MiniCourse.WebUI.Baskets.ViewModels;
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

            jsonModel.Message = "Kurs Sepete Eklendi";
            jsonModel.IsValid = true;

            //var courseResponse = await response.Content.ReadFromJsonAsync<CourseCreateResponse>();

            //var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            //tempData["SuccessMessage"] = $"Kurs Sepete Eklendi";

            return ServiceResult<CustomJsonModel>.Success(jsonModel);
        }
    }
}
