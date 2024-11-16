using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Users;
using MiniCourse.Service.Roles.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Roles
{
    public class RoleService(RoleManager<AppRole> roleManager):IRoleService
    {
        public async Task<ApiServiceResult<List<RoleResponse>>> GetRolesAsync()
        {

            var rolesResponseList = await roleManager.Roles.Select(x => new RoleResponse()
            {
                Id = x.Id.ToString(),
                Name = x.Name!
            }).ToListAsync();

            return ApiServiceResult<List<RoleResponse>>.Success(rolesResponseList, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<RoleResponse>> GetRoleAsync(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role is null)
            {
                return ApiServiceResult<RoleResponse>.Fail("Rol bulunamadi", HttpStatusCode.NotFound);
            }

            var roleResponse = new RoleResponse { Name=role.Name ,Id=role.Id.ToString()};

            return ApiServiceResult<RoleResponse>.Success(roleResponse, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<CreateRoleResponse>> CreateRoleAsync(CreateRoleRequest request)
        {
            var newRole = new AppRole{ Name = request.Name,};

            var result = await roleManager.CreateAsync(newRole);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult<CreateRoleResponse>.Fail(errorList, HttpStatusCode.BadRequest);
            }

            return ApiServiceResult<CreateRoleResponse>.Success(new CreateRoleResponse { Name = newRole.Name }, HttpStatusCode.Created);

        }

        public async Task<ApiServiceResult> UpdateRoleAsync(UpdateRoleRequest request)
        {
            var role = await roleManager.FindByIdAsync(request.Id.ToString());

            if (role == null)
            {
                return ApiServiceResult.Fail("Rol bulunamadi", HttpStatusCode.NotFound);
            }

            role.Name = request.Name;

            var result = await roleManager.UpdateAsync(role);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult.Fail(errorList, HttpStatusCode.BadRequest);
            }

            return ApiServiceResult.Success(HttpStatusCode.OK);

        }

        public async Task<ApiServiceResult> DeleteRoleAsync(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return ApiServiceResult.Fail("Rol Bulunamadi", HttpStatusCode.NotFound);
            }

            var result = await roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult.Fail(errorList, HttpStatusCode.BadRequest);
            }

            return ApiServiceResult.Success(HttpStatusCode.OK);
        }
    }
}
