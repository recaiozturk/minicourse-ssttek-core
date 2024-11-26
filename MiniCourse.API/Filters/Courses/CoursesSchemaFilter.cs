using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MiniCourse.Service.Categories.DTOs;
using MiniCourse.Service.Courses.DTOs;
using MiniCourse.Service.Shared;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class CoursesSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CreateCourseRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["Title"] = new OpenApiString("Yeni Kurs Başlığı"),
                    ["Description"] = new OpenApiString("Kurs açıklaması burada yer alacak."),
                    ["Price"] = new OpenApiDouble(199),
                    ["CategoryId"] = new OpenApiInteger(1),
                    ["CourseImage"] = new OpenApiString("kurs_resmi.jpg")
                };
            }

            if (context.Type == typeof(UpdateCourseRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["Id"] = new OpenApiInteger(1),
                    ["Title"] = new OpenApiString("Güncellenmiş Kurs Başlığı"),
                    ["Description"] = new OpenApiString("Güncellenmiş kurs açıklaması."),
                    ["Price"] = new OpenApiDouble(199),
                    ["CategoryId"] = new OpenApiInteger(2),
                    ["CourseImage"] = new OpenApiString("guncellenmis_kurs_resmi.jpg")
                };
            }
        }
    }
}
