using MiniCourse.Repository.Courses;

namespace MiniCourse.Repository.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public List<Course>? Courses { get; set; }
    }
}
