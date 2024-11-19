using MiniCourse.Repository.Categories;

namespace MiniCourse.WebUI.Courses.DTOs
{
    public record CourseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        //public string CategoryName { get; set; } = default!; 
        public Category? Category { get; set; }
        public string? CourseImage { get; set; } 
    }
}
