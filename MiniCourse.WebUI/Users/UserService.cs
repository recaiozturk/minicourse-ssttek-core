using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.Users.DTOs;
using AdminModel = MiniCourse.WebUI.Areas.Admin.Models;



namespace MiniCourse.WebUI.Users
{
    public class UserService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) :IUserService
    {
        public async Task<ServiceResult<List<AdminModel.UserViewModel>>> GetUsersAsync()
        {
            var address = "/api/Users/getusers";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<List<AdminModel.UserViewModel>>.Fail(problemDetail!.Detail!);
            }

            var users=await response.Content.ReadFromJsonAsync<List<UserResponse>>();

            List<AdminModel.UserViewModel> userList = new();

            if(users!=null)
            {
                users.ForEach(x => userList.Add(new AdminModel.UserViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email
                }));
            }

            //var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            //tempData["SuccessMessage"] = "Kaydınız Başarili şekilde oluştu";

            return ServiceResult<List<AdminModel.UserViewModel>>.Success(userList);

        }
    }
}
