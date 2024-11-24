using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Courses;

namespace MiniCourse.WebUI.Controllers
{
    public class HomeController(ICourseService courseService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var coursesPagedResult = await courseService.PrepareHomeListPageAsync();
            return View(coursesPagedResult.Data);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }


    }
}
