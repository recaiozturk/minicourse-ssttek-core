using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniCourse.Service.Auths;
using MiniCourse.Service.Baskets;
using MiniCourse.Service.Categories;
using MiniCourse.Service.Courses;
using MiniCourse.Service.Members;
using MiniCourse.Service.Orders;
using MiniCourse.Service.Payments;
using MiniCourse.Service.Roles;
using MiniCourse.Service.Users;

namespace MiniCourse.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApiServicesExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
