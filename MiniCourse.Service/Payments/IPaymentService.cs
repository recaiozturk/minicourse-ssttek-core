using MiniCourse.Service.Payments.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Payments
{
    public interface IPaymentService
    {
        Task<ApiServiceResult> ProcessPaymentAsync(PaymentRequest request);
    }
}
