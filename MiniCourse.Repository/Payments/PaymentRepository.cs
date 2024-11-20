using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Payments
{
    public class PaymentRepository(AppDbContext context) : GenericRepository<Payment>(context), IPaymentRepository
    {
    }
}
