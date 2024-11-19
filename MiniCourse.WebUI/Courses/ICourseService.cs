using MiniCourse.WebUI.Courses.DTOs;
using MiniCourse.WebUI.Courses.ViewModels;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.ViewModels;

namespace MiniCourse.WebUI.Courses
{
    public interface ICourseService
    {
        Task<ServiceResult<List<CourseViewModel>>> GetCoursesAsync();
        Task<ServiceResult<HomeViewModel>> PrepareHomeListPageAsync();
        Task<ServiceResult<CoursesPagedModel>> PrepareListPageAsync(int pageNumber, int pageSize, int catId);
        Task<ServiceResult<CourseUpdateViewModel>> GetCourseAsync(int courseId);
        Task<ServiceResult<CourseResponse>> GetCourseWithCategoryAsync(int courseId);
        Task<ServiceResult> CreateCourseAsync(CourseCreateViewModel model);
        Task<ServiceResult> UpdateCourseAsync(CourseUpdateViewModel model);
        Task<ServiceResult> DeleteCourseAsync(int courseId);
    }
}
