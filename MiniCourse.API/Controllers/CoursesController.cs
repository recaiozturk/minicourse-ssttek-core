using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Courses;
using MiniCourse.Service.Courses.DTOs;

namespace MiniCourse.API.Controllers
{
    public class CoursesController(ICourseService courseService) : CustomControllerBase
    {
        [HttpGet("get-courses")]
        public async Task<IActionResult> GetCoursesAsync()
        {
            var result = await courseService.GetCoursesAsync();
            return CreateObjectResult(result);
        }

        [HttpGet("get-courses-with-category")]
        public async Task<IActionResult> GetCoursesWithCategory()
        {
            var result = await courseService.GetCoursesWithCategoryAsync();
            return CreateObjectResult(result);
        }

        [HttpGet("get-courses-paged")]
        public async Task<IActionResult> GetCoursesPagedAsync(int pageNumber,int pageSize, int catId)
        {
            var result = await courseService.GetCoursesPagedAsync(pageNumber, pageSize, catId);
            return CreateObjectResult(result);
        }

        [HttpGet("get-courses-by-category")]
        public async Task<IActionResult> GetCoursesByCategoryAsync(int catId)
        {
            var result = await courseService.GetCoursesByCategoryAsync(catId);
            return CreateObjectResult(result);
        }

        [HttpGet("get-course")]
        public async Task<IActionResult> GetCourseAsync(int courseId)
        {
            var result = await courseService.GetCourseAsync(courseId);
            return CreateObjectResult(result);
        }

        [HttpGet("get-course-with-category")]
        public async Task<IActionResult> GetCourseWithCategoryAsync(int courseId)
        {
            var result = await courseService.GetCourseWithCategoryAsync(courseId);
            return CreateObjectResult(result);
        }

        [HttpPost("create-course")]
        public async Task<IActionResult> CreateCourseAsync(CreateCourseRequest request)
        {
            var result = await courseService.CreateCourseAsync(request);
            return CreateObjectResult(result);
        }

        [HttpPut("update-course")]
        public async Task<IActionResult> UpdateCourseAsync(UpdateCourseRequest request)
        {
            var result = await courseService.UpdateCourseAsync(request);
            return CreateObjectResult(result);
        }

        [HttpDelete("delete-course")]
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
