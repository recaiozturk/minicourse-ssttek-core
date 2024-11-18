using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Courses
{
    public class CourseRepository(AppDbContext context) : GenericRepository<Course>(context), ICourseRepository
    {
        public async Task<Course?> GetByIdWithCategoryAsync(int id)
        {
            var courseWithCategory = await context.Courses.Include(b => b.Category).FirstOrDefaultAsync(x => x.Id == id);
            return courseWithCategory;
        }

        public IQueryable<Course> GetCoursesWithCategoryQuaaryble()
        {
            return context.Courses.AsNoTracking().AsQueryable();
        }
    }
}
