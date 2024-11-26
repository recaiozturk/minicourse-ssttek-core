using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class UsersOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "GetUsersAsync")
            {
                operation.Summary = "Kullanıcıları listeleyin";
                operation.Description = "Tüm kullanıcıları getirir.";
            }

            if (context.MethodInfo.Name == "GetUserAsync")
            {
                operation.Summary = "Kullanıcıyı getir";
                operation.Description = "Belirli bir kullanıcıyı kullanıcı kimliğine göre getirir.";
            }

            if (context.MethodInfo.Name == "CreateUsersAsync")
            {
                operation.Summary = "Yeni kullanıcı oluştur";
                operation.Description = "Verilen bilgilerle yeni bir kullanıcı oluşturur.";
            }

            if (context.MethodInfo.Name == "UpdateUsersAsync")
            {
                operation.Summary = "Kullanıcı bilgilerini güncelle";
                operation.Description = "Verilen kullanıcı bilgileri ile mevcut kullanıcıyı günceller.";
            }

            if (context.MethodInfo.Name == "DeleteUsersAsync")
            {
                operation.Summary = "Kullanıcıyı silme işlemi";
                operation.Description = "Verilen kullanıcı ID'sine göre kullanıcıyı siler.";

            }
        }
    }
}
