using Microsoft.AspNetCore.Mvc;

namespace MiniCourse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        public IActionResult UserList()
        {
            return View();
        }
    }
}
