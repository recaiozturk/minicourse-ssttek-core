
using MiniCourse.Repository.Categories;

namespace MiniCourse.Repository.Courses
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public string? CourseImage { get; set; }

        public Category Category { get; set; }
    }
}
