using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Users;

namespace MiniCourse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController(IUserService userService) : Controller
    {
        public async Task<IActionResult> UserList()
        {
            var usersResult = await userService.GetUsersAsync();

            return View(usersResult.Data);
        }
    }
}
