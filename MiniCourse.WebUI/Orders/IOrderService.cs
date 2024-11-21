using MiniCourse.WebUI.Orders.DTOs;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.Orders
{
    public interface IOrderService
    {
        Task<ServiceResult<OrderResponse>> CreateOrderAsync();
        Task<ServiceResult<List<OrderResponse>>> GetOrdersByUserIdAsync();
    }
}
