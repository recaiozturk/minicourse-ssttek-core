using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Users;
using MiniCourse.WebUI.Users.ViewModels;

namespace MiniCourse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController(IUserService userService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var usersResult = await userService.GetUsersAsync();
            return View(usersResult.Data);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateViewModel model)
        {
            var createUserResult = await userService.CreateUserAsync(model);

            if (createUserResult.AnyError)
            {
                foreach (var error in createUserResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }
            return RedirectToAction(nameof(UserList));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(string userId)
        {
            var userResult = await userService.GetUserAsync(userId);
            return View(userResult.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateViewModel model)
        {
            var createUserResult = await userService.UpdateUserAsync(model);

            if (createUserResult.AnyError)
            {
                foreach (var error in createUserResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }
            return RedirectToAction(nameof(UserList));
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            var deleteUserResult = await userService.DeleteUserAsync(userId);

            if (deleteUserResult.AnyError)
            {
                foreach (var error in deleteUserResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View();
            }
            return RedirectToAction(nameof(UserList));
        }
    }
}
