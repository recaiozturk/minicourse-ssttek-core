using MiniCourse.Service.Shared;
using MiniCourse.Service.Users.DTOs;

namespace MiniCourse.Service.Users
{
    public interface IUserService
    {
        Task<ApiServiceResult<List<UserResponse>>> GetUsersAsync();
        Task<ApiServiceResult<UserResponse>> GetUserAsync(string userId);
        Task<ApiServiceResult<CreateUserResponse>> CreateUsersAsync(CreateUserRequest request);
        Task<ApiServiceResult> UpdateUsersAsync(UpdateUserRequest request);
        Task<ApiServiceResult> DeleteUsersAsync(string userId);
    }
}
