using Microsoft.OpenApi.Models;
using MiniCourse.Service.Auths.DTOs;
using MiniCourse.Service.Baskets.DTOs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class BasketsSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(AddBasketRequest))
            {
                schema.Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["courseId"] = new Microsoft.OpenApi.Any.OpenApiInteger(101),
                    ["quantity"] = new Microsoft.OpenApi.Any.OpenApiInteger(2),
                    ["userId"] = new Microsoft.OpenApi.Any.OpenApiString("user123")
                };
            }
        }
    }
}
