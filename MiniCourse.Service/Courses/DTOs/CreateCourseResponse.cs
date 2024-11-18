namespace MiniCourse.Service.Courses.DTOs
{
    public record CreateCourseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string? CourseImage { get; set; }
    }
}
