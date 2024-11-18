using MiniCourse.Repository.Courses;
using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Categories
{
    public class CategoryRepository(AppDbContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
    }
}
