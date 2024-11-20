using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MiniCourse.WebUI.Payments.ViewModels;
using MiniCourse.WebUI.Shared;
using System.Security.Claims;

namespace MiniCourse.WebUI.Payments
{
    public class PaymentService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory) :IPaymentService
    {
        public async Task<ServiceResult> ProcessPaymentAsync(PaymentViewModel model)
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
                return ServiceResult.Fail("Kullanici bulunamadi");

            var address = $"/api/Payments/process-payment";
            var response = await client.PostAsJsonAsync(address, model);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            //var orderResponse = await response.Content.ReadFromJsonAsync<OrderResponse>();

            return ServiceResult.Success();
        }
    }
}
