namespace MiniCourse.WebUI.Courses.DTOs
{
    public record CourseCreateResponse
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty; 
    }
}
