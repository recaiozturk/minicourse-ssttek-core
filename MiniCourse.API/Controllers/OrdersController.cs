using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Orders;

namespace MiniCourse.API.Controllers
{
    public class OrdersController(IOrderService orderService) : CustomControllerBase
    {
        [HttpGet("create-order")]
        public async Task<IActionResult> AddToBasketAsync(string userId)
        {
            var result = await orderService.CreateOrderAsync(userId);
            return CreateObjectResult(result);
        }
    }
}
