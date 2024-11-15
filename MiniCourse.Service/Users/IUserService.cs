using MiniCourse.Service.Shared;
using MiniCourse.Service.Users.DTOs;

namespace MiniCourse.Service.Users
{
    public interface IUserService
    {
        Task<ApiServiceResult<List<UserResponse>>> GetUsersAsync();
    }
}
