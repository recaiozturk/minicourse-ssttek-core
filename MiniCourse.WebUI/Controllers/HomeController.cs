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

        public IActionResult SampleErrors()
        {
            return View();
        }
        public IActionResult DivideByZeroError()
        {
            int x = 3;
            int y = 0;
            var result = x / y;
            return View();
        }
        public IActionResult NullReferenceException()
        {
            string? nullString = null;
            int stringLength = nullString.Length;

            return View();
        }

        




    }
}
