using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.Categories;
using MiniCourse.Repository.Courses;
using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Extensions
{
    public static class RepoExtension
    {
        public static IServiceCollection AddRepoExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICourseRepository,CourseRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
