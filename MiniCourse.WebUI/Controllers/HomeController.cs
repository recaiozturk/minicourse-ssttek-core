using Microsoft.AspNetCore.Mvc;

namespace MiniCourse.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
