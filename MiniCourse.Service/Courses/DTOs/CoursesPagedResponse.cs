namespace MiniCourse.Service.Courses.DTOs
{
    public record CoursesPagedResponse
    {
        public List<CourseResponse>? Courses { get; set; }
        public int TotalPages { get; set; }
    }
}
