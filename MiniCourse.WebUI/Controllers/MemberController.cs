using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Members;
using MiniCourse.WebUI.Members.ViewModels;

namespace MiniCourse.WebUI.Controllers
{
    public class MemberController(IMemberService memberService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var result = await memberService.GetProfileInfoAsync();
            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> ProfileUpdate()
        {
            var result = await memberService.GetProfileUpdateInfoAsync();
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileUpdate(MemberProfileUpdateViewModel viewModel)
        {
            var updateResult = await memberService.UpdateMemberProfileAsync(viewModel);

            if (updateResult.AnyError)
            {
                foreach (var error in updateResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(viewModel);
            }

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
            var passwordResult = await memberService.ChangeMemberPasswordAsync(viewModel);

            if (passwordResult.AnyError)
            {
                foreach (var error in passwordResult.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(viewModel);
            }

            return RedirectToAction(nameof(Profile));
        }

    }
}
