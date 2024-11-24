using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Users;

namespace MiniCourse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class HomeController(IUserService userService) : Controller
    {
        public IActionResult Index()
        {
            var test = userService.GetUsersAsync();
            return View();
        }
    }
}
