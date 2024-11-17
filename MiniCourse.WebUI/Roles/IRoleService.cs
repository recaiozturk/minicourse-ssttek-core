using MiniCourse.WebUI.Roles.ViewModels;
using MiniCourse.WebUI.Shared;


namespace MiniCourse.WebUI.Roles
{
    public interface IRoleService
    {
        Task<ServiceResult<List<RoleViewModel>>> GetRolesAsync();
        Task<ServiceResult<List<RoleViewModel>>> GetRolesByUserAsync(string userId);
        Task<ServiceResult<List<AssignRoleToUserViewModel>>> GetAssignRoleModelAsync(string userId);
        Task<ServiceResult> AssignRoleToUserAsync(string userId, List<AssignRoleToUserViewModel> requestList);
        Task<ServiceResult> CreateRoleAsync(RoleCreateViewModel model);
        Task<ServiceResult<RoleUpdateViewModel>> GetRoleAsync(string roleId);
        Task<ServiceResult> UpdateRoleAsync(RoleUpdateViewModel model);
        Task<ServiceResult> DeleteRoleAsync(string roleId);
    }
}
