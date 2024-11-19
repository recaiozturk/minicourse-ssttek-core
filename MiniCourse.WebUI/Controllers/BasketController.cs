using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Baskets;

namespace MiniCourse.WebUI.Controllers
{
    public class BasketController(IBasketService basketService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddToBasket(int courseId, int quantity)
        {
            var result = await basketService.AddCourseToBasketAsync(courseId, quantity);
            return Json(result.Data);
        }


    }
}
