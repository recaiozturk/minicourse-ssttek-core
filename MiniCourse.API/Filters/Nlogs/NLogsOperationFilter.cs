using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class NLogsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "CreateLogAsync")
            {
                operation.Summary = "Hata logu kaydetme işlemi";
                operation.Description = "Verilen hata bilgileri ile bir hata logu kaydedilir.";
            }

            if (context.MethodInfo.Name == "GetLogsAsync")
            {
                operation.Summary = "Logları getirme işlemi";
                operation.Description = "Tüm log kayıtlarını alır.";
            }


            if (context.MethodInfo.Name == "DeleteLogAsync")
            {
                operation.Summary = "Log silme işlemi";
                operation.Description = "Belirli bir log kaydını siler.";
            }
        }
    }
}
