using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class BasketsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "AddToBasketAsync")
            {
                operation.Summary = "Sepete ürün ekleme işlemi";
                operation.Description = "Kullanıcı sepete kurs ekler. Kursun ID'si, miktarı ve kullanıcı kimliği gönderilir.";
            }

            if (context.MethodInfo.Name == "GetBasketByUserIdAsync")
            {
                operation.Summary = "Kullanıcının sepet bilgilerini getirme";
                operation.Description = "Belirtilen kullanıcı kimliği (userId) ile sepet bilgilerini döner.";
            }

            if (context.MethodInfo.Name == "GetBasketDetailAsync")
            {
                operation.Summary = "Kullanıcı sepet detaylarını getirir";
                operation.Description = "Belirtilen kullanıcı kimliği (userId) ile sepetin detay bilgilerini döner.";
            }

            if (context.MethodInfo.Name == "RemoveItemFromBasketAsync")
            {
                operation.Summary = "Sepetten ürün çıkarma işlemi";
                operation.Description = "Belirtilen kullanıcı kimliği (userId) ve kurs ID'si (courseId) ile sepetteki ürünü çıkarır.";
              
            }
        }
    }
}
