using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Baskets;
using MiniCourse.Service.Baskets.DTOs;

namespace MiniCourse.API.Controllers
{
    public class BasketsController(IBasketService basketService) : CustomControllerBase
    {
        [HttpPost("add-to-basket")]
        public async Task<IActionResult> AddToBasketAsync(AddBasketRequest request)
        {
            var result = await basketService.AddToBasketAsync(request);
            return CreateObjectResult(result);
        }

        [HttpGet("get-basket")]
        public async Task<IActionResult> GetBasketByUserIdAsync(string userId)
        {
            var result = await basketService.GetBasketByUserIdAsync(userId);
            return CreateObjectResult(result);
        }

        [HttpGet("get-basket-detail")]
        public async Task<IActionResult> GetBasketDetailAsync(string userId)
        {
            var result = await basketService.GetBasketDetailAsync(userId);
            return CreateObjectResult(result);
        }

        [HttpDelete("remove-from-basket")]
        public async Task<IActionResult> RemoveItemFromBasketAsync(string userId,int courseId)
        {
            var result = await basketService.RemoveItemFromBasketAsync(userId,courseId);
            return CreateObjectResult(result);
        }


    }
}
