using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class MembersOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "GetUserProfileAsync")
            {
                operation.Summary = "Kullanıcı profil bilgilerini alma işlemi";
                operation.Description = "Verilen kullanıcı kimliği ile kullanıcı profil bilgileri alınır.";
            }

            if (context.MethodInfo.Name == "UpdateMemberProfileAsync")
            {
                operation.Summary = "Üye profilini güncelleme işlemi";
                operation.Description = "Verilen kullanıcı bilgilerini kullanarak üye profilini günceller.";

            }

            if (context.MethodInfo.Name == "ChangeMemberPasswordAsync")
            {
                operation.Summary = "Üye şifresini değiştirme işlemi";
                operation.Description = "Mevcut şifresini girerek, yeni bir şifre belirler.";
            }
        }
    }
}
