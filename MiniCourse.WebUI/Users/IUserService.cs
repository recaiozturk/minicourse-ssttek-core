using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.Users.ViewModels;


namespace MiniCourse.WebUI.Users
{
    public interface IUserService
    {
        Task<ServiceResult<List<UserViewModel>>> GetUsersAsync();
        Task<ServiceResult<UserUpdateViewModel>> GetUserAsync(string userId);
        Task<ServiceResult> CreateUserAsync(UserCreateViewModel model);
        Task<ServiceResult> UpdateUserAsync(UserUpdateViewModel model);
        Task<ServiceResult> DeleteUserAsync(string userId);
    }
}
