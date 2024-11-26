using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MiniCourse.Service.Payments.DTOs;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniCourse.API.Filters.Auth
{
    public class PaymentsSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(PaymentRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["OrderId"] = new OpenApiInteger(1),
                    ["NameForBill"] = new OpenApiString("John"),
                    ["LastNameForBill"] = new OpenApiString("Doe"),
                    ["AdressForBill"] = new OpenApiString("123 Main St"),
                    ["CardHolderName"] = new OpenApiString("John Doe"),
                    ["CardNumber"] = new OpenApiString("4111111111111111"),
                    ["ExpiryDate"] = new OpenApiString("12/24"),
                    ["CVV"] = new OpenApiString("123"),
                    ["BasketId"] = new OpenApiInteger(1)
                };
            }
        }
    }
}
