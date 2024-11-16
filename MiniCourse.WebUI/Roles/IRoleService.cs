using MiniCourse.WebUI.Roles.ViewModels;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.Users.ViewModels;


namespace MiniCourse.WebUI.Roles
{
    public interface IRoleService
    {
        Task<ServiceResult<List<RoleViewModel>>> GetRolesAsync();
        Task<ServiceResult> CreateRoleAsync(RoleCreateViewModel model);
        Task<ServiceResult<RoleUpdateViewModel>> GetRoleAsync(string roleId);
        Task<ServiceResult> UpdateRoleAsync(RoleUpdateViewModel model);
        Task<ServiceResult> DeleteRoleAsync(string roleId);
        //Task<ServiceResult<UserUpdateViewModel>> GetUserAsync(string userId);
        //Task<ServiceResult> CreateUserAsync(UserCreateViewModel model);
        //Task<ServiceResult> UpdateUserAsync(UserUpdateViewModel model);
        //Task<ServiceResult> DeleteUserAsync(string userId);
    }
}
