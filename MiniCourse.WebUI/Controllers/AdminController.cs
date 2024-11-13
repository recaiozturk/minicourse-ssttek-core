using Microsoft.AspNetCore.Mvc;

namespace MiniCourse.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
