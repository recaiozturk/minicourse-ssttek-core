using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.ViewModels;

namespace MiniCourse.WebUI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(int x)
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(int x)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            //var currentUserName = User.Identity!.Name;

            //var result = await authService.GetProfileInfo(currentUserName!);

            //if (result.AnyError)
            //{
            //    TempData["error"] = result.Errors;
            //}

            //return View(result.Data);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProfileUpdate()
        {
            //var result = await authService.GetProfileInfo(User.Identity!.Name!);

            //if (result.AnyError)
            //    TempData["error"] = result.Errors;

            //return View(result.Data);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProfileUpdate(UpdateProfileViewModel viewModel)
        {
            //var result = await authService.UpdateProfile(viewModel, User.Identity!.Name!);

            //if (result.AnyError)
            //    TempData["error"] = result.Errors;

            //TempData["success"] = "Profiliniz başarı ile güncellendi";

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        public async Task<IActionResult> PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(ChangePasswordViewModel viewModel)
        {
            //var result = await authService.ChangePassword(viewModel, User.Identity!.Name!);

            //if (result.AnyError)
            //{
            //    TempData["error"] = result.Errors;
            //    return View(viewModel);
            //}

            //TempData["success"] = "Şifreniz başarılı bir şekilde güncellendi";

            return RedirectToAction(nameof(Profile));
        }
    }
}
