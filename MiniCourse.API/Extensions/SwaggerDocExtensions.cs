using MiniCourse.API.Filters.Auth;
using System.Reflection;

namespace MiniCourse.API.Extensions
{
    public static class SwaggerDocExtensions
    {
        public static IServiceCollection AddSwaggerDocExt(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<AuthSchemaFilter>();
                c.OperationFilter<AuthOperationFilter>();

                c.SchemaFilter<BasketsSchemaFilter>();
                c.OperationFilter<BasketsOperationFilter>();

                c.SchemaFilter<CategoriesSchemaFilter>();
                c.OperationFilter<CategoriesOperationFilter>();

                c.SchemaFilter<ClientsSchemaFilter>();
                c.OperationFilter<ClientsOperationFilter>();

                c.SchemaFilter<CoursesSchemaFilter>();
                c.OperationFilter<CoursesOperationFilter>();

                c.SchemaFilter<MembersSchemaFilter>();
                c.OperationFilter<MembersOperationFilter>();

                c.SchemaFilter<NlogsSchemaFilter>();
                c.OperationFilter<NLogsOperationFilter>();

                c.SchemaFilter<OrdersSchemaFilter>();
                c.OperationFilter<OrdersOperationFilter>();

                c.SchemaFilter<PaymentsSchemaFilter>();
                c.OperationFilter<PaymentsOperationFilter>();

                c.SchemaFilter<UsersSchemaFilter>();
                c.OperationFilter<UsersOperationFilter>();

                c.SchemaFilter<RolesSchemaFilter>();
                c.OperationFilter<RolesOperationFilter>();
            });

            return services;
        }
    }
}
