using MiniCourse.Service.Baskets.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Baskets
{
    public interface IBasketService
    {
        Task<ApiServiceResult<AddBasketResponse>> AddToBasketAsync(AddBasketRequest request);
    }
}
