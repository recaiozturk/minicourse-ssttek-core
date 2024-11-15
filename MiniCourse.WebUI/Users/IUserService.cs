using MiniCourse.WebUI.Shared;
using AdminModel = MiniCourse.WebUI.Areas.Admin.Models;

namespace MiniCourse.WebUI.Users
{
    public interface IUserService
    {
        Task<ServiceResult<List<AdminModel.UserViewModel>>> GetUsersAsync();
    }
}
