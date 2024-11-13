using Microsoft.AspNetCore.Mvc;

namespace MiniCourse.WebUI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
