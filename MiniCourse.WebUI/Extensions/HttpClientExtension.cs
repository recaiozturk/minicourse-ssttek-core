using MiniCourse.WebUI.Auths;
using MiniCourse.WebUI.Baskets;
using MiniCourse.WebUI.Categories;
using MiniCourse.WebUI.Courses;
using MiniCourse.WebUI.Handlers;
using MiniCourse.WebUI.Members;
using MiniCourse.WebUI.NLogs;
using MiniCourse.WebUI.Orders;
using MiniCourse.WebUI.Payments;
using MiniCourse.WebUI.Roles;
using MiniCourse.WebUI.Users;

namespace MiniCourse.WebUI.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddHttpClientExt(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHttpClient<IAuthService, AuthService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            });

            services.AddHttpClient<IUserService, UserService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            }).AddHttpMessageHandler<ClientCredentialHandler>();


            services.AddHttpClient<IRoleService, RoleService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            }).AddHttpMessageHandler<ClientCredentialHandler>(); ;

            services.AddHttpClient<IMemberService, MemberService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            }).AddHttpMessageHandler<ClientCredentialHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            }).AddHttpMessageHandler<ClientCredentialHandler>();

            services.AddHttpClient<ICourseService, CourseService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            }).AddHttpMessageHandler<ClientCredentialHandler>();

            services.AddHttpClient<IBasketService, BasketService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            }).AddHttpMessageHandler<ClientCredentialHandler>();

            services.AddHttpClient<IOrderService, OrderService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            }).AddHttpMessageHandler<ClientCredentialHandler>();

            services.AddHttpClient<IPaymentService, PaymentService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            }).AddHttpMessageHandler<ClientCredentialHandler>();

            services.AddHttpClient<INLogService, NLogService>(x =>
            {
                x.BaseAddress = new Uri(configuration.GetSection("ApiOption")["BaseAddress"]!);
            }).AddHttpMessageHandler<ClientCredentialHandler>();

            return services;
        }
    }
}
