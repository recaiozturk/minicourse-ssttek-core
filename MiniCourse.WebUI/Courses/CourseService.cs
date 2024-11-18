using MiniCourse.WebUI.Courses.ViewModels;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.Courses
{
    public class CourseService : ICourseService
    {
        public Task<ServiceResult> CreateCourseAsync(CourseCreateViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> DeleteCourseAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<CourseUpdateViewModel>> GetCourseAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<List<CourseViewModel>>> GetCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateCourseAsync(CourseUpdateViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
