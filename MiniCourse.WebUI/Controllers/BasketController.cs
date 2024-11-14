using Microsoft.AspNetCore.Mvc;

namespace MiniCourse.WebUI.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Basket()
        {
            return View();
        }


    }
}
