using MiniCourse.Service.Baskets.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Baskets
{
    public interface IBasketService
    {
        Task<ApiServiceResult<AddBasketResponse>> AddToBasketAsync(AddBasketRequest request);
        Task<ApiServiceResult<BasketResponse>> GetBasketByUserIdAsync(string userId);
        Task<ApiServiceResult> RemoveItemFromBasketAsync(string userId, int courseId);
        Task<ApiServiceResult<BasketDetailResponse>> GetBasketDetailAsync(string userId);
    }
}
