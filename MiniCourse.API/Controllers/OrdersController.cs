using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Orders;

namespace MiniCourse.API.Controllers
{
    [Authorize]
    public class OrdersController(IOrderService orderService) : CustomControllerBase
    {
        [HttpGet("create-order")]
        public async Task<IActionResult> CreateOrderAsync(string userId)
        {
            var result = await orderService.CreateOrderAsync(userId);
            return CreateObjectResult(result);
        }

        [HttpGet("get-orders-by-userid")]
        public async Task<IActionResult> GetOrdersByUserIdAsync(string userId)
        {
            var result = await orderService.GetOrdersByUserIdAsync(userId);
            return CreateObjectResult(result);
        }
    }
}
