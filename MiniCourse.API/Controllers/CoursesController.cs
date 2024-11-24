using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Courses;
using MiniCourse.Service.Courses.DTOs;

namespace MiniCourse.API.Controllers
{
    public class CoursesController(ICourseService courseService) : CustomControllerBase
    {
        [HttpGet("getcourses")]
        public async Task<IActionResult> GetCoursesAsync()
        {
            var result = await courseService.GetCoursesAsync();
            return CreateObjectResult(result);
        }

        [HttpGet("getcourseswithcategory")]
        public async Task<IActionResult> GetCoursesWithCategory()
        {
            var result = await courseService.GetCoursesWithCategoryAsync();
            return CreateObjectResult(result);
        }

        [HttpGet("getcoursespaged")]
        public async Task<IActionResult> GetCoursesPagedAsync(int pageNumber,int pageSize, int catId)
        {
            var result = await courseService.GetCoursesPagedAsync(pageNumber, pageSize, catId);
            return CreateObjectResult(result);
        }

        [HttpGet("getcoursesbycategory")]
        public async Task<IActionResult> GetCoursesByCategoryAsync(int catId)
        {
            var result = await courseService.GetCoursesByCategoryAsync(catId);
            return CreateObjectResult(result);
        }

        [HttpGet("getcourse")]
        public async Task<IActionResult> GetCourseAsync(int courseId)
        {
            var result = await courseService.GetCourseAsync(courseId);
            return CreateObjectResult(result);
        }

        [HttpGet("getcoursewithcategory")]
        public async Task<IActionResult> GetCourseWithCategoryAsync(int courseId)
        {
            var result = await courseService.GetCourseWithCategoryAsync(courseId);
            return CreateObjectResult(result);
        }

        [HttpPost("createcourse")]
        public async Task<IActionResult> CreateCourseAsync(CreateCourseRequest request)
        {
            var result = await courseService.CreateCourseAsync(request);
            return CreateObjectResult(result);
        }

        [HttpPut("updatecourse")]
        public async Task<IActionResult> UpdateCourseAsync(UpdateCourseRequest request)
        {
            var result = await courseService.UpdateCourseAsync(request);
            return CreateObjectResult(result);
        }

        [HttpDelete("deletecourse")]
        public async Task<IActionResult> DeleteCourseAsync(int courseId)
        {
            var result = await courseService.DeleteCourseAsync(courseId);
            return CreateObjectResult(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCourseAsync(string searchValue)
        {
            var result = await courseService.SearchCourseAsync(searchValue);
            return CreateObjectResult(result);
        }

        
    }
}
