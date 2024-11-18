using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Courses;

namespace MiniCourse.WebUI.Controllers
{
    public class HomeController(ICourseService courseService) : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index(int catId=0)
        {
            var coursesPagedResult = await courseService.PrepareHomeListPageAsync(catId);
            return View(coursesPagedResult.Data);
        }



        public IActionResult AccessDenied()
        {
            return View();
        }

        
    }
}
