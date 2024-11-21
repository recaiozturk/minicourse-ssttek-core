using MiniCourse.Service.Orders.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Orders
{
    public interface IOrderService
    {
        Task<ApiServiceResult<OrderResponse>> CreateOrderAsync(string userId);
        Task<ApiServiceResult<List<OrderResponse>>> GetOrdersByUserIdAsync(string userId);
    }
}
