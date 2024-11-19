using AutoMapper;
using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.Shared;
using MiniCourse.Service.Baskets.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Baskets
{
    public class BasketService(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IMapper mapper) :IBasketService
    {
        public async Task<ApiServiceResult<AddBasketResponse>> AddToBasketAsync(AddBasketRequest request)
        {

            // Kullanıcıya ait sepeti al
            var basket = await basketRepository.GetBasketByUserIdAsync(request.UserId);

            // Sepet yoksa, yeni bir sepet oluştur
            if (basket == null)
            {
                basket = new Basket
                {
                    UserId = request.UserId,
                    Items = new List<BasketItem>()
                };

                await basketRepository.AddAsync(basket);
                await unitOfWork.CommitAsync();
            }

            // Sepetteki öğeyi kontrol et
            var existingItem = basket.Items.FirstOrDefault(bi => bi.CourseId == request.CourseId);

            if (existingItem != null)
            {
                // Eğer kurs zaten sepette varsa, miktarı güncelle
                existingItem.Quantity += request.Quantity;
                basketRepository.Update(basket);
            }
            else
            {
                // Eğer kurs sepette yoksa, yeni bir BasketItem ekle
                var newItem = new BasketItem
                {
                    BasketId = basket.Id,
                    CourseId = request.CourseId,
                    Quantity = request.Quantity
                };

                await basketRepository.AddItemToBasketAsync(newItem);
            }

            await unitOfWork.CommitAsync();

            AddBasketResponse response = new AddBasketResponse();
            response.BasketItemsCount= basket.Items.Count;

            return ApiServiceResult<AddBasketResponse>.Success(response, HttpStatusCode.Created);
        }
    }
}
