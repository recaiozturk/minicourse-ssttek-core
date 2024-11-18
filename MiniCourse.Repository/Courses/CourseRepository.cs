using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Courses
{
    public class CourseRepository(AppDbContext context) : GenericRepository<Course>(context), ICourseRepository
    {
    }
}
