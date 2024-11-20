﻿using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.Orders;
using MiniCourse.Repository.Payments;
using MiniCourse.Repository.Shared;
using MiniCourse.Service.Baskets.DTOs;
using MiniCourse.Service.Payments.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Payments
{
    public class PaymentService(IOrderRepository orderRepository,IPaymentRepository paymentRepository,IUnitOfWork unitOfWork):IPaymentService
    {
        public async Task<ApiServiceResult> ProcessPaymentAsync(PaymentRequest request)
        {

            var order=await orderRepository.GetByIdAsync(request.OrderId);

            if(order == null)
                return ApiServiceResult.Fail("Sipariş bulunamadi", HttpStatusCode.NotFound);

            var payment = new Payment
            {
                OrderId = order.Id, // Sipariş ID'si
                UserId = order.UserId.ToString(),
                Amount = order.TotalAmount,
                PaymentDate = DateTime.UtcNow,
                IsSuccessful = true // Ödeme başarılı
            };

            await paymentRepository.AddAsync(payment);
            await unitOfWork.CommitAsync();
            await Task.Delay(5000);

            return ApiServiceResult.Success(HttpStatusCode.OK);

        }
    }
}
