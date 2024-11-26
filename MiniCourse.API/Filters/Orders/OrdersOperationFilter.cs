using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class OrdersOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "CreateOrderAsync")
            {
                operation.Summary = "Sipariş oluşturma işlemi";
                operation.Description = "Belirli bir kullanıcı için yeni bir sipariş oluşturur.";
            }

            if (context.MethodInfo.Name == "GetOrdersByUserIdAsync")
            {
                operation.Summary = "Kullanıcıya ait siparişleri getirir";
                operation.Description = "Belirli bir kullanıcı ID'si ile, o kullanıcıya ait tüm siparişlerin detayları döndürülür.";
            }
        }
    }
}
