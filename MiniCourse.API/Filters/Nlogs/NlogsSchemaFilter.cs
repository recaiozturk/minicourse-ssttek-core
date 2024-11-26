using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MiniCourse.Service.Nlogs.DTOs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class NlogsSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(ExceptionRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["Message"] = new OpenApiString("NullReferenceException occurred."),
                    ["Source"] = new OpenApiString("MyApp.Services.SomeService"),
                    ["StackTrace"] = new OpenApiString("at MyApp.Services.SomeService.DoSomething()..."),
                    ["LoggedAt"] = new OpenApiString("2024-11-26T15:00:00Z")
                };
            }
        }
    }
}
