using Microsoft.OpenApi.Models;
using MiniCourse.Service.Auths.DTOs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class AuthSchemaFilter: ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(SignInRequest))
            {
                schema.Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["email"] = new Microsoft.OpenApi.Any.OpenApiString("user@example.com"),
                    ["password"] = new Microsoft.OpenApi.Any.OpenApiString("Password.123")
                };
            }

            if (context.Type == typeof(SignUpRequest))
            {
                schema.Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["userName"] = new Microsoft.OpenApi.Any.OpenApiString("john_doe"),
                    ["password"] = new Microsoft.OpenApi.Any.OpenApiString("Password123!"),
                    ["rePassword"] = new Microsoft.OpenApi.Any.OpenApiString("Password123!"),
                    ["email"] = new Microsoft.OpenApi.Any.OpenApiString("john.doe@example.com"),
                    ["city"] = new Microsoft.OpenApi.Any.OpenApiString("Istanbul")
                };
            }
        }
    }
}
