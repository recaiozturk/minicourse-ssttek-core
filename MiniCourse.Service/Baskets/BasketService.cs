using AutoMapper;
using Azure;
using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.Shared;
using MiniCourse.Service.Baskets.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Baskets
{
    public class BasketService(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IMapper mapper) :IBasketService
    {
        public async Task<ApiServiceResult<BasketResponse>> GetBasketByUserIdAsync(string userId)
        {
            var basket = await basketRepository.GetBasketByUserIdAsync(userId);

            if(basket is null)
                return ApiServiceResult<BasketResponse>.Fail("Sepet bulunamadi",HttpStatusCode.NotFound);

            var response = mapper.Map<BasketResponse>(basket);

            return ApiServiceResult<BasketResponse>.Success(response, HttpStatusCode.Created);
        }

        public async Task<ApiServiceResult<BasketDetailResponse>> GetBasketDetailAsync(string userId)
        {
            var basket = await basketRepository.GetBasketByUserIdAsync(userId);

            if (basket == null)
                return ApiServiceResult<BasketDetailResponse>.Fail("Sepet bulunamadi", HttpStatusCode.NotFound);

            var basketDetail = new BasketDetailResponse
            {
                Items = basket.Items.Select(item => new BasketItemResponse
                {
                    CourseId = item.CourseId,
                    CourseName = item.Course.Title,
                    Quantity = item.Quantity,
                    UnitPrice = item.Course.Price
                }).ToList()
            };

            basketDetail.TotalPrice = basketDetail.Items.Sum(item => item.TotalPrice);

            return ApiServiceResult<BasketDetailResponse>.Success(basketDetail, HttpStatusCode.Created);

        }

        public async Task<ApiServiceResult> RemoveItemFromBasketAsync(string userId,int courseId)
        {
            var basket = await basketRepository.GetBasketByUserIdAsync(userId);

            if (basket == null)
                return ApiServiceResult.Fail("Sepet bulunamadı.",HttpStatusCode.NotFound);

            var itemToRemove = basket.Items.FirstOrDefault(item => item.CourseId == courseId);

            if (itemToRemove == null)
                return ApiServiceResult.Fail("Sepette bu ürün bulunamadı.", HttpStatusCode.NotFound);

            basket.Items.Remove(itemToRemove);

            basketRepository.Update(basket);
            await unitOfWork.CommitAsync();

            return ApiServiceResult.Success(HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<AddBasketResponse>> AddToBasketAsync(AddBasketRequest request)
        {

            var basket = await basketRepository.GetBasketByUserIdAsync(request.UserId);

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

            var existingItem = basket.Items.FirstOrDefault(bi => bi.CourseId == request.CourseId);

            if (existingItem != null)
            {
                existingItem.Quantity += request.Quantity;
                basketRepository.Update(basket);
            }
            else
            {
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
