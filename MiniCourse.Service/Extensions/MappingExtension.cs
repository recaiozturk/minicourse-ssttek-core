using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MiniCourse.Service.Extensions
{
    public static class MappingExtension
    {
        public static IServiceCollection AddMappingExt(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
