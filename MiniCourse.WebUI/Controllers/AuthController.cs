using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Auths;
using MiniCourse.WebUI.Auths.ViewModels;

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
    }
}
