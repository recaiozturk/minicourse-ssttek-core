using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Baskets;
using MiniCourse.Service.Baskets.DTOs;
using MiniCourse.Service.Courses.DTOs;

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
    }
}
