using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Courses;

namespace MiniCourse.WebUI.Controllers
{
    public class CoursesController(ICourseService courseService) : Controller
    {
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 3)
        {
            var coursesPagedResult = await courseService.PrepareListPageAsync(pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(coursesPagedResult.Data);
        }
    }
}
