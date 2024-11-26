using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class PaymentsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "ProcessPaymentAsync")
            {
                operation.Summary = "Ödeme işlemi gerçekleştirir";
                operation.Description = "Verilen ödeme bilgileri ile ödeme işlemi yapılır.";
            }


        }
    }
}
