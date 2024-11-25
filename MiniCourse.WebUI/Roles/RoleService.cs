using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MiniCourse.WebUI.Roles;
using MiniCourse.WebUI.Roles.DTOs;
using MiniCourse.WebUI.Roles.ViewModels;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.Users.DTOs;




namespace MiniCourse.WebUI.Users
{
    public class RoleService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) : IRoleService
    {


        public async Task<ServiceResult<RoleUpdateViewModel>> GetRoleAsync(string roleId)
        {
            var address = $"/api/Roles/get-role?roleId={roleId}";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<RoleUpdateViewModel>.Fail(problemDetail!.Detail!);
            }

            var role = await response.Content.ReadFromJsonAsync<RoleResponse>();

            RoleUpdateViewModel roleViewModel = new RoleUpdateViewModel { Name = role.Name, Id = role.Id };


            return ServiceResult<RoleUpdateViewModel>.Success(roleViewModel);

        }

        public async Task<ServiceResult<List<RoleViewModel>>> GetRolesAsync()
        {
            var address = "/api/Roles/get-roles";
            var response = await client.GetAsync(address);


            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<List<RoleViewModel>>.Fail(problemDetail!.Detail!);
            }

            var roles = await response.Content.ReadFromJsonAsync<List<RoleViewModel>>();

            List<RoleViewModel> roleList = new();

            if (roles != null)
            {
                roles.ForEach(x => roleList.Add(new RoleViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }));
            }

            return ServiceResult<List<RoleViewModel>>.Success(roleList);

        }
        public async Task<ServiceResult<List<RoleViewModel>>> GetRolesByUserAsync(string userId)
        {
            var address = $"/api/Roles/get-roles-by-user-id?userId={userId}";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<List<RoleViewModel>>.Fail(problemDetail!.Detail!);
            }

            var roles = await response.Content.ReadFromJsonAsync<List<RoleViewModel>>();

            List<RoleViewModel> roleList = new();

            if (roles != null)
            {
                roles.ForEach(x => roleList.Add(new RoleViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }));
            }

            return ServiceResult<List<RoleViewModel>>.Success(roleList);

        }

        public async Task<ServiceResult> CreateRoleAsync(RoleCreateViewModel model)
        {
            var address = "/api/Roles/create-role";

            var response = await client.PostAsJsonAsync(address, model);


            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var roleResponse = await response.Content.ReadFromJsonAsync<RoleCreateResponse>();

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $"'{roleResponse!.Name}' rolü başarili şekilde oluştu";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> UpdateRoleAsync(RoleUpdateViewModel model)
        {
            var address = "/api/Roles/update-role";

            var response = await client.PutAsJsonAsync(address, model);


            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $" rol Başarili şekilde güncellendi";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteRoleAsync(string roleId)
        {
            var address = $"/api/Roles/delete-role?roleId={roleId}";

            var response = await client.DeleteAsync(address);


            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $" Rol Başarili şekilde silindi";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult<List<AssignRoleToUserViewModel>>> GetAssignRoleModelAsync(string userId)
        {

            var roles = await GetRolesAsync();
            var userRoles = await GetRolesByUserAsync(userId);

            var userRoleNames = new HashSet<string>(userRoles.Data.Select(r => r.Name));

            var roleViewModelList = roles.Data.Select(role => new AssignRoleToUserViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Exist = userRoleNames.Contains(role.Name) 
            }).ToList();

            return ServiceResult<List<AssignRoleToUserViewModel>>.Success(roleViewModelList);

        }
        public async Task<ServiceResult> AssignRoleToUserAsync(string userId, List<AssignRoleToUserViewModel> requestList)
        {
            var address = $"/api/Roles/assign-Role-To-User?userId={userId}";

            var response = await client.PostAsJsonAsync(address, requestList);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $" Rol Atama Başarili şekilde gerçekleşti";

            return ServiceResult.Success();
        }
        
    }
}
