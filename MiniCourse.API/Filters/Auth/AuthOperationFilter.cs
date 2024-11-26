using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class AuthOperationFilter: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "SignInAsync")
            {
                operation.Summary = "Kullanıcı giriş işlemi";
                operation.Description = "Email ve şifre kullanarak oturum açma işlemi yapılır.";
            }

            if (context.MethodInfo.Name == "SignUpAsync")
            {
                operation.Summary = "Kullanıcı kayıt işlemi";
                operation.Description = "Yeni bir kullanıcı oluşturmak için gerekli bilgilerin gönderildiği işlem.";
            }
        }
    }
}
