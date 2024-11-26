using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MiniCourse.Service.Categories.DTOs;
using MiniCourse.Service.Shared;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class ClientsSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(SignInClientCredentialRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["clientId"] = new OpenApiString("client123"),
                    ["clientSecret"] = new OpenApiString("secret123")
                };

                schema.Properties["clientId"].Description = "Client Credentials ile giriş yapmak için kullanılan benzersiz client ID.";
                schema.Properties["clientSecret"].Description = "Client Credentials ile giriş yapmak için kullanılan client secret.";
            }
        }
    }
}
