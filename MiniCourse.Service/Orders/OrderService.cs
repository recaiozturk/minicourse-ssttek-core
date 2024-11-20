using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.OrderDetails;
using MiniCourse.Repository.Orders;
using MiniCourse.Repository.Shared;
using MiniCourse.Service.Orders.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Orders
{
    public class OrderService(IOrderRepository orderRepository,IBasketRepository basketRepository,IUnitOfWork unitOfWork):IOrderService
    {
        public async Task<ApiServiceResult<OrderResponse>> CreateOrderAsync(string userId)
        {
            // Kullanıcıya ait sepeti al
            var basket = await basketRepository.GetBasketByUserIdAsync(userId);

            if (basket == null || !basket.Items.Any())
                return ApiServiceResult<OrderResponse>.Fail("Sepetiniz boş. Sipariş oluşturulamadı.", HttpStatusCode.BadRequest);

            // Sipariş oluşturma
            var order = new Order
            {
                UserId = Guid.Parse(userId),
                CreatedDate = DateTime.UtcNow,
                TotalAmount = basket.Items.Sum(item => item.Quantity * item.Course.Price),
                OrderStatus = (int)OrderStatus.Pending, // Sipariş durumu "Beklemede" olarak ayarlanıyor
                OrderDetails = basket.Items.Select(item => new OrderDetail
                {
                    CourseId = item.CourseId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Course.Price
                }).ToList()
            };

            // Siparişi veritabanına ekle
            await orderRepository.AddAsync(order);

            // Sepeti temizle
            await basketRepository.DeleteBasketAsync(basket.Id);

            // Veritabanı işlemlerini kaydet
            await unitOfWork.CommitAsync();

            // Yanıt oluştur
            var orderResponse = new OrderResponse
            {
                OrderId = order.Id,
                TotalPrice = order.TotalAmount,
                CreatedDate = order.CreatedDate,
                OrderStatus=order.OrderStatus,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailResponse
                {
                    CourseId = od.CourseId,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                }).ToList()
            };

            return ApiServiceResult<OrderResponse>.Success(orderResponse, HttpStatusCode.Created);
        }
    }
}
