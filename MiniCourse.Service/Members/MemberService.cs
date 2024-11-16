using Microsoft.AspNetCore.Identity;
using MiniCourse.Repository.Users;
using MiniCourse.Service.Members.DTOs;
using MiniCourse.Service.Roles.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Members
{
    public class MemberService(UserManager<AppUser> userManager) : IMemberService
    {
        public async Task<ApiServiceResult<MemberProfileResult>> GetUserProfileAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return ApiServiceResult<MemberProfileResult>.Fail("Kullanıcı bulunamadi", HttpStatusCode.NotFound);
            }

            var memberProfileResponse = new MemberProfileResult { UserName=user.UserName,Email=user.Email,City=user.City};

            return ApiServiceResult<MemberProfileResult>.Success(memberProfileResponse, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult> UpdateMemberProfileAsync(UpdateMemberProfileRequest request)
        {
            var user = await userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                return ApiServiceResult.Fail("Kullanici bulunamadi", HttpStatusCode.NotFound);
            }

            user.UserName = request.UserName;
            user.Email = request.Email;
            user.City = request.City;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult.Fail(errorList, HttpStatusCode.BadRequest);
            }

            return ApiServiceResult.Success(HttpStatusCode.OK);

        }

        public async Task<ApiServiceResult> ChangeMemberPasswordAsync(ChangeMemberPasswordRequest request)
        {
            var user = await userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                return ApiServiceResult.Fail("Kullanici bulunamadi", HttpStatusCode.NotFound);
            }

            var result = await userManager.ChangePasswordAsync(user, request.OldPassword, request.Password);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult.Fail(errorList, HttpStatusCode.BadRequest);
            }

            return ApiServiceResult.Success(HttpStatusCode.OK);

        }
    }
}
