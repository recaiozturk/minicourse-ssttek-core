using MiniCourse.WebUI.Payments.ViewModels;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.Payments
{
    public interface IPaymentService
    {
        Task<ServiceResult> ProcessPaymentAsync(PaymentViewModel model);
    }
}
