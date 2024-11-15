using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Extensions
{
    public static class RepoExtension
    {
        public static IServiceCollection AddRepoExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
