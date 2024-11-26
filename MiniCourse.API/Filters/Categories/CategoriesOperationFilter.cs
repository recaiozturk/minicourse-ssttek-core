using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class CategoriesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name == "GetCategoriesAsync")
            {
                operation.Summary = "Tüm kategorileri getirir";
                operation.Description = "Bu işlem, mevcut kategorilerin listesini döndürür.";
            }

            if (context.MethodInfo.Name == "GetCategoryAsync")
            {
                operation.Summary = "Belirli bir kategoriyi getirir";
                operation.Description = "Bu işlem, belirtilen kategori ID'sine göre kategorinin detaylarını döndürür.";              
            }

            if (context.MethodInfo.Name == "CreateCategoryAsync")
            {
                operation.Summary = "Yeni kategori oluşturma işlemi";
                operation.Description = "Bu işlem, yeni bir kategori oluşturur.";               
            }

            if (context.MethodInfo.Name == "UpdateCategoryAsync")
            {
                operation.Summary = "Var olan kategoriyi günceller";
                operation.Description = "Bu işlem, belirtilen kategori ID'si ve yeni adı ile mevcut kategoriyi günceller.";                
            }

            if (context.MethodInfo.Name == "DeleteCategoryAsync")
            {
                operation.Summary = "Kategori silme işlemi";
                operation.Description = "Bu işlem, verilen kategori ID'sine göre kategoriyi siler.";
            }
        }
    }
}
