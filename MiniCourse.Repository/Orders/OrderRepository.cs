using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Orders
{
    public class OrderRepository(AppDbContext context) : GenericRepository<Order>(context), IOrderRepository
    {
    }
}
