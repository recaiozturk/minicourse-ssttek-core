namespace MiniCourse.Service.Courses.DTOs
{
    public record CreateCourseRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? CourseImage { get; set; }
    }
}
