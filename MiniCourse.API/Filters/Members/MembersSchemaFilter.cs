using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MiniCourse.Service.Members.DTOs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class MembersSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(UpdateMemberProfileRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["userId"] = new OpenApiString("user123"),
                    ["userName"] = new OpenApiString("John Doe"),
                    ["email"] = new OpenApiString("john.doe@example.com"),
                    ["city"] = new OpenApiString("New York")
                };
            }

            if (context.Type == typeof(ChangeMemberPasswordRequest))
            {
                // Model için örnek değerler ekliyoruz
                schema.Example = new OpenApiObject
                {
                    ["userId"] = new OpenApiString("user123"),
                    ["oldPassword"] = new OpenApiString("oldPassword.123"),
                    ["password"] = new OpenApiString("newPassword.123"),
                    ["rePassword"] = new OpenApiString("newPassword.123")
                };
            }
        }
    }
}
