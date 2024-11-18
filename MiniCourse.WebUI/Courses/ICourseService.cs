using MiniCourse.WebUI.Courses.ViewModels;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.ViewModels;

namespace MiniCourse.WebUI.Courses
{
    public interface ICourseService
    {
        Task<ServiceResult<List<CourseViewModel>>> GetCoursesAsync();
        Task<ServiceResult<CoursesPagedModel>> PrepareListPageAsync(int pageNumber, int pageSize);

        Task<ServiceResult<HomeViewModel>> PrepareHomeListPageAsync(int catId);
        Task<ServiceResult<CourseUpdateViewModel>> GetCourseAsync(int courseId);
        Task<ServiceResult> CreateCourseAsync(CourseCreateViewModel model);
        Task<ServiceResult> UpdateCourseAsync(CourseUpdateViewModel model);
        Task<ServiceResult> DeleteCourseAsync(int courseId);
    }
}
