using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.Orders;
using MiniCourse.Repository.Payments;
using MiniCourse.Repository.Shared;
using MiniCourse.Service.Baskets.DTOs;
using MiniCourse.Service.Payments.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Payments
{
    public class PaymentService(IOrderRepository orderRepository,IPaymentRepository paymentRepository,IBasketRepository basketRepository,IUnitOfWork unitOfWork):IPaymentService
    {
        public async Task<ApiServiceResult> ProcessPaymentAsync(PaymentRequest request)
        {
            var order=await orderRepository.GetByIdAsync(request.OrderId);

            if(order == null)
                return ApiServiceResult.Fail("Sipariş bulunamadi", HttpStatusCode.NotFound);

            var payment = new Payment
            {
                OrderId = order.Id, 
                UserId = order.UserId.ToString(),
                Amount = order.TotalAmount,
                PaymentDate = DateTime.UtcNow,
                IsSuccessful = true 
            };

            await paymentRepository.AddAsync(payment);

            //sepeti burda sil
            await basketRepository.DeleteBasketAsync(request.BasketId);

            await unitOfWork.CommitAsync();
            await Task.Delay(5000);

            return ApiServiceResult.Success(HttpStatusCode.OK);

        }
    }
}
