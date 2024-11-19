using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.Baskets
{
    public interface IBasketService
    {
        Task<ServiceResult<CustomJsonModel>> AddCourseToBasketAsync(int courseId, int quantity);
    }
}
