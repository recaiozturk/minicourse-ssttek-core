using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class RolesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "GetRolesAsync")
            {
                operation.Summary = "Kullanıcı rolleri alınır.";
                operation.Description = "Veritabanındaki tüm kullanıcı rolleri listelenir.";
            }

            if (context.MethodInfo.Name == "GetRolesByUserIdAsync")
            {
                operation.Summary = "Belirli bir kullanıcı için rolleri getirir.";
                operation.Description = "Verilen userId'ye sahip kullanıcının sahip olduğu roller listelenir.";
            }

            if (context.MethodInfo.Name == "GetRoleAsync")
            {
                operation.Summary = "Belirli bir rolü getirir.";
                operation.Description = "Verilen roleId'ye sahip rolün detaylarını getirir.";
            }

            if (context.MethodInfo.Name == "CreateRoleAsync")
            {
                operation.Summary = "Yeni bir rol oluşturur.";
                operation.Description = "Verilen rol adı ile yeni bir rol oluşturur.";
            }

            if (context.MethodInfo.Name == "AssignRoleToUserAsync")
            {
                operation.Summary = "Kullanıcıya bir veya birden fazla rol atar.";
                operation.Description = "Belirtilen kullanıcıya bir veya birden fazla rol atamak için kullanılır.";
            }

            if (context.MethodInfo.Name == "UpdateRoleAsync")
            {
                operation.Summary = "Mevcut bir rolü günceller";
                operation.Description = "Sistemdeki mevcut bir rolün detaylarını güncellemeye olanak tanır.";
            }

            if (context.MethodInfo.Name == "DeleteRoleAsync")
            {
                operation.Summary = "Bir rolü benzersiz kimliği ile siler.";
                operation.Description = "Bu işlem, sağlanan rol kimliği ile bir rolü sistemden siler.";

            }

        }
    }
}
