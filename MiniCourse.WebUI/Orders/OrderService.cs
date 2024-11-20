using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MiniCourse.WebUI.Orders.DTOs;
using MiniCourse.WebUI.Shared;
using System.Security.Claims;

namespace MiniCourse.WebUI.Orders
{
    public class OrderService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory) :IOrderService
    {
        public async Task<ServiceResult<OrderResponse>> CreateOrderAsync()
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId is null)
                return ServiceResult<OrderResponse>.Fail("Sipariş oluşturk için Giriş yapmalisiniz");

            var address = $"/api/Orders/create-order?userId={userId}";
            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<OrderResponse>.Fail(problemDetail!.Detail!);
            }

            var orderResponse = await response.Content.ReadFromJsonAsync<OrderResponse>();

            return ServiceResult<OrderResponse>.Success(orderResponse);
        }
    }
}
