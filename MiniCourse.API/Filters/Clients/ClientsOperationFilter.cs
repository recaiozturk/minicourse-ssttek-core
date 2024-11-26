using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class ClientsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "SignInClientCredentialAsync")
            {
                operation.Summary = "Client Credentials ile giriş işlemi";
                operation.Description = "Bu işlem, client ID ve client secret kullanarak giriş yapar.";
            }
        }
    }
}
