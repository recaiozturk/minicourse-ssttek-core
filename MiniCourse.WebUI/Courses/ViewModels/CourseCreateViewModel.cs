namespace MiniCourse.WebUI.Courses.ViewModels
{
    public record CourseCreateViewModel
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; }= default!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public string? CourseImage { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
