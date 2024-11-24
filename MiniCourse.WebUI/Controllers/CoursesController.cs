using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Courses;

namespace MiniCourse.WebUI.Controllers
{
    public class CoursesController(ICourseService courseService) : Controller
    {
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 3,int catId=0)
        {
            var coursesPagedResult = await courseService.PrepareListPageAsync(pageNumber, pageSize,catId);
            ViewBag.CurrentPage = pageNumber;
            return View(coursesPagedResult.Data);
        }

        [HttpGet("courses/detail/{courseId}")]
        public async Task<IActionResult> Detail(int courseId)
        {
            var coursesDetailResult = await courseService.GetCourseAsync(courseId);
            return View(coursesDetailResult.Data);
        }

        [HttpPost]
        public async Task<JsonResult> SearchCourse(string searchValue)
        {
            var result = await courseService.SearchCourseAsync(searchValue);
            return Json(result.Data);
        }
    }
}
