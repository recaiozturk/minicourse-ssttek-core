using MiniCourse.WebUI.Baskets.DTOs;
using MiniCourse.WebUI.Baskets.ViewModels;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.Baskets
{
    public interface IBasketService
    {
        Task<ServiceResult<CustomJsonModel>> AddCourseToBasketAsync(int courseId, int quantity);
        Task<ServiceResult<BasketDetailViewModel>> GetBasketDetailAsync();
        Task<ServiceResult<BasketResponse>> GetBasketByUserIdAsync();
        Task<ServiceResult> RemoveItemFromBasketAsync(int courseId);
    }
}
