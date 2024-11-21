using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Orders
{
    public class OrderRepository(AppDbContext context) : GenericRepository<Order>(context), IOrderRepository
    {
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.UserId == Guid.Parse(userId))
                .ToListAsync();
        }
    }
}
