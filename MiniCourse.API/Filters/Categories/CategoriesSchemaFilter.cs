using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MiniCourse.Service.Categories.DTOs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class CategoriesSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CreateCategoryRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["name"] = new OpenApiString("Yeni Kategori")
                };

                schema.Properties["name"].Description = "Kategori adı. Bu alan zorunludur ve 1 ile 100 karakter arasında olmalıdır.";
            }

            if (context.Type == typeof(UpdateCategoryRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["id"] = new OpenApiInteger(1),
                    ["name"] = new OpenApiString("Yeni Güncellenmiş Kategori")
                };

                schema.Properties["id"].Description = "Güncellenmesi istenen kategorinin benzersiz ID'si.";
                schema.Properties["name"].Description = "Yeni kategori adı. Bu alan zorunludur ve 1 ile 100 karakter arasında olmalıdır.";
            }
        }
    }
}
