using MiniCourse.WebUI.Courses.DTOs;

namespace MiniCourse.WebUI.Courses.ViewModels
{
    public class CoursesPagedModel
    {
        public List<CourseViewModel>? Courses { get; set; }
        public int TotalPages { get; set; }

        public string? CourseTitle { get; set; }
    }
}
