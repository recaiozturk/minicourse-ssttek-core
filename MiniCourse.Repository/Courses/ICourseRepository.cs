using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Courses
{
    public interface ICourseRepository: IGenericRepository<Course>
    {
        Task<Course?> GetByIdWithCategoryAsync(int id);
        IQueryable<Course> GetCoursesWithCategoryQuaaryble();
    }
}
