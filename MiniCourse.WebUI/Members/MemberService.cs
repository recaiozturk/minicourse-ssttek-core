using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MiniCourse.WebUI.Members.ViewModels;
using MiniCourse.WebUI.Shared;
using System.Security.Claims;

namespace MiniCourse.WebUI.Members
{
    public class MemberService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) :IMemberService
    {

        
        public async Task<ServiceResult> UpdateMemberProfileAsync(MemberProfileUpdateViewModel model)
        {
            var address = "/api/Members/updatemember";

            model.UserId= httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await client.PutAsJsonAsync(address, model);


            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $" Profiliniz Başarili şekilde güncellendi";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult<MemberProfileViewModel>> GetProfileInfoAsync()
        {
            var currentUSerId= httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var address = $"/api/Members/getuserprofile?userId={currentUSerId}";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<MemberProfileViewModel>.Fail(problemDetail!.Detail!);
            }

            var memberProfile = await response.Content.ReadFromJsonAsync<MemberProfileViewModel>();
            return ServiceResult<MemberProfileViewModel>.Success(memberProfile);
        }

        public async Task<ServiceResult<MemberProfileUpdateViewModel>> GetProfileUpdateInfoAsync()
        {
            var currentUSerId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var address = $"/api/Members/getuserprofile?userId={currentUSerId}";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<MemberProfileUpdateViewModel>.Fail(problemDetail!.Detail!);
            }

            var memberProfile = await response.Content.ReadFromJsonAsync<MemberProfileViewModel>();

            var memberUpdateProfileInfo = new MemberProfileUpdateViewModel { UserName=memberProfile.UserName, Email=memberProfile.Email ,City=memberProfile.City};

            return ServiceResult<MemberProfileUpdateViewModel>.Success(memberUpdateProfileInfo);
        }

        public async Task<ServiceResult> ChangeMemberPasswordAsync(ChangePasswordViewModel model)
        {
            var currentUSerId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.UserId = currentUSerId;

            var address = $"/api/Members/changepassword";

            var response = await client.PutAsJsonAsync(address,model);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $"Şifreniz başarili şekilde değiştirildi";

            return ServiceResult.Success();
        }

        
    }
}
