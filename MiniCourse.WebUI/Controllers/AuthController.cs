using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Auths;
using MiniCourse.WebUI.Auths.ViewModels;
using MiniCourse.WebUI.ViewModels;

namespace MiniCourse.WebUI.Controllers
{
    public class AuthController(IAuthService authService) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            var response = await authService.SignInAsync(model);

            if (response.AnyError)
            {
                foreach (var error in response.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model )
        {
            var response = await authService.SignUpAsync(model);

            if (response.AnyError)
            {
                foreach (var error in response.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }
            return View(nameof(SignIn));
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
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
