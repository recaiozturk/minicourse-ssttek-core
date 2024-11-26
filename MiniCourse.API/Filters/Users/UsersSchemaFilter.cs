using Microsoft.OpenApi.Models;
using MiniCourse.Service.Users.DTOs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class UsersSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CreateUserRequest))
            {
                schema.Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["UserName"] = new Microsoft.OpenApi.Any.OpenApiString("Kullanıcı adı, en az 5 karakter uzunluğunda olmalıdır."),
                    ["Email"] = new Microsoft.OpenApi.Any.OpenApiString("Geçerli bir e-posta adresi girilmelidir."),
                    ["Password"] = new Microsoft.OpenApi.Any.OpenApiString("Şifre, en az 8 karakter uzunluğunda ve bir rakam içermelidir."),
                    ["City"] = new Microsoft.OpenApi.Any.OpenApiString("Kullanıcının yaşadığı şehir adı.")
                };
            }

            if (context.Type == typeof(UpdateUserRequest))
            {
                schema.Example = new Microsoft.OpenApi.Any.OpenApiObject
                {
                    ["UserName"] = new Microsoft.OpenApi.Any.OpenApiString("Güncellenmiş kullanıcı adı."),
                    ["Email"] = new Microsoft.OpenApi.Any.OpenApiString("Geçerli bir e-posta adresi girilmelidir."),
                    ["Password"] = new Microsoft.OpenApi.Any.OpenApiString("Yeni şifre, en az 8 karakter uzunluğunda ve bir rakam içermelidir."),
                    ["City"] = new Microsoft.OpenApi.Any.OpenApiString("Kullanıcının yaşadığı yeni şehir adı."),
                    ["UserID"] = new Microsoft.OpenApi.Any.OpenApiString("Güncellenecek kullanıcının benzersiz kimliği.")
                };
            }
        }
    }
}
