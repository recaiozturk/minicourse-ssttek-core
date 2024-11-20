using Microsoft.AspNetCore.Mvc;
using MiniCourse.Repository.Courses;
using MiniCourse.WebUI.Baskets;
using System.Security.Claims;

namespace MiniCourse.WebUI.Controllers
{
    public class BasketController(IBasketService basketService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await basketService.GetBasketDetailAsync();

            if (result.AnyError)
                return RedirectToAction(nameof(Index), "Home");

            return View(result.Data);
        }

        [HttpPost]
        public async Task<JsonResult> AddToBasket(int courseId, int quantity)
        {
            var result = await basketService.AddCourseToBasketAsync(courseId, quantity);
            return Json(result.Data);
        }


        public async Task<IActionResult> RemoveItemFromBasket(int courseId)
        {
            var result = await basketService.RemoveItemFromBasketAsync(courseId);
            return RedirectToAction(nameof(Index));
        }
    }
}
