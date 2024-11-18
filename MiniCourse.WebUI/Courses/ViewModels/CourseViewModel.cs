namespace MiniCourse.WebUI.Courses.ViewModels
{
    public record CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
