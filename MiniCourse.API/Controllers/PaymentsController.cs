using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Payments;
using MiniCourse.Service.Payments.DTOs;

namespace MiniCourse.API.Controllers
{
    [Authorize]
    public class PaymentsController(IPaymentService paymentService) : CustomControllerBase
    {
        [HttpPost("process-payment")]
        public async Task<IActionResult> ProcessPaymentAsync(PaymentRequest request)
        {
            var result = await paymentService.ProcessPaymentAsync(request);
            return CreateObjectResult(result);
        }
    }
}
