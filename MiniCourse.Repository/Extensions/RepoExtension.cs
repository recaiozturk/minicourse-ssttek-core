using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.Categories;
using MiniCourse.Repository.Courses;
using MiniCourse.Repository.NLogs;
using MiniCourse.Repository.Orders;
using MiniCourse.Repository.Payments;
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
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<INLogrepository, NLogrepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
