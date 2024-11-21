using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Orders
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
