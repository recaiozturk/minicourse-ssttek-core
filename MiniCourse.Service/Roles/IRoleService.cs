using MiniCourse.Service.Roles.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Roles
{
    public interface IRoleService
    {
        Task<ApiServiceResult<List<RoleResponse>>> GetRolesAsync();
        Task<ApiServiceResult<CreateRoleResponse>> CreateRoleAsync(CreateRoleRequest request);
        Task<ApiServiceResult<RoleResponse>> GetRoleAsync(string roleId);
        Task<ApiServiceResult> UpdateRoleAsync(UpdateRoleRequest request);
        Task<ApiServiceResult> DeleteRoleAsync(string roleId);
    }
}
