using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.Users.DTOs;
using MiniCourse.WebUI.Users.ViewModels;



namespace MiniCourse.WebUI.Users
{
    public class UserService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) : IUserService
    {
        public async Task<ServiceResult<List<UserViewModel>>> GetUsersAsync()
        {
            var address = "/api/Users/get-users";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<List<UserViewModel>>.Fail(problemDetail!.Detail!);
            }

            var users = await response.Content.ReadFromJsonAsync<List<UserResponse>>();

            List<UserViewModel> userList = new();

            if (users != null)
            {
                users.ForEach(x => userList.Add(new UserViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email
                }));
            }

            return ServiceResult<List<UserViewModel>>.Success(userList);

        }

        public async Task<ServiceResult<UserUpdateViewModel>> GetUserAsync(string userId)
        {
            var address = $"/api/Users/get-user?userId={userId}";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<UserUpdateViewModel>.Fail(problemDetail!.Detail!);
            }

            var user = await response.Content.ReadFromJsonAsync<UserResponse>();

            UserUpdateViewModel userViewModel = new UserUpdateViewModel
            {
                UserName = user.Name,
                Email = user.Email,
                City = user.City,
                UserID=user.Id
            };

            return ServiceResult<UserUpdateViewModel>.Success(userViewModel);

        }

        public async Task<ServiceResult> CreateUserAsync(UserCreateViewModel model)
        {
            var address = "/api/Users/create-user";

            var response = await client.PostAsJsonAsync(address, model);


            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var userResponse = await response.Content.ReadFromJsonAsync<UserCreateResponse>();

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $"{userResponse!.UserName} adli kullanıcı Başarili şekilde oluştu";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> UpdateUserAsync(UserUpdateViewModel model)
        {
            var address = "/api/Users/update-user";

            var response = await client.PutAsJsonAsync(address, model);


            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $" Kullanıcı Başarili şekilde güncellendi";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteUserAsync(string userId)
        {
            var address = $"/api/Users/delete-user?userId={userId}";

            var response = await client.DeleteAsync(address);


            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $" Kullanıcı Başarili şekilde silindi";

            return ServiceResult.Success();
        }


    }
}
