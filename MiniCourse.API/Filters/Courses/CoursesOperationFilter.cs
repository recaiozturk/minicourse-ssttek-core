using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class CoursesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "GetCoursesAsync")
            {
                operation.Summary = "Tüm kursları listele";
                operation.Description = "Bu işlem, mevcut tüm kursları listeler.";
            }

            if (context.MethodInfo.Name == "GetCoursesWithCategory")
            {
                operation.Summary = "Kursları kategori bilgisiyle listele";
                operation.Description = "Bu işlem, tüm kursları ve her kursun ait olduğu kategori bilgisini listeler.";
            }

            if (context.MethodInfo.Name == "GetCoursesPagedAsync")
            {
                operation.Summary = "Sayfalanmış kursları listele";
                operation.Description = "Bu işlem, verilen sayfa numarası ve sayfa boyutuna göre kategorilerle filtrelenmiş kursları listeler.";
            }
            if (context.MethodInfo.Name == "GetCoursesByCategoryAsync")
            {
                operation.Summary = "Kategoriye ait kursları listele";
                operation.Description = "Bu işlem, verilen kategori kimliğine göre o kategoriye ait kursları listeler.";
            }

            if (context.MethodInfo.Name == "GetCourseAsync")
            {
                operation.Summary = "Belirli bir kursu al";
                operation.Description = "Bu işlem, verilen kurs kimliğine göre belirli bir kursu alır.";
            }

            if (context.MethodInfo.Name == "GetCourseWithCategoryAsync")
            {
                operation.Summary = "Belirli bir kurs ve kategorisini al";
                operation.Description = "Bu işlem, verilen kurs kimliğine göre belirli bir kursu ve ilgili kategori bilgisini alır.";
            }

            if (context.MethodInfo.Name == "CreateCourseAsync")
            {
                operation.Summary = "Yeni bir kurs oluştur";
                operation.Description = "Bu işlem, yeni bir kurs oluşturur ve veritabanına kaydeder.";
            }

            if (context.MethodInfo.Name == "UpdateCourseAsync")
            {
                operation.Summary = "Var olan kursu güncelle";
                operation.Description = "Bu işlem, var olan bir kursun bilgilerini günceller.";
            }

            if (context.MethodInfo.Name == "DeleteCourseAsync")
            {
                operation.Summary = "Kurs silme işlemi";
                operation.Description = "Belirtilen kurs kimliği ile kursu siler.";
            }

            if (context.MethodInfo.Name == "SearchCourseAsync")
            {
                operation.Summary = "Kurs arama işlemi";
                operation.Description = "Kullanıcı tarafından sağlanan arama değeri ile kurslar aranır.";
            }
        }
    }
}
