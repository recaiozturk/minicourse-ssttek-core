using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Users;
using MiniCourse.Service.Shared;
using MiniCourse.Service.Users.DTOs;
using System.Net;
using System.Security.Claims;

namespace MiniCourse.Service.Users
{
    public class UserService(UserManager<AppUser> userManager):IUserService
    {
        public async Task<ApiServiceResult<List<UserResponse>>> GetUsersAsync()
        {
            var userList = await userManager.Users.ToListAsync();

            var userResponseList = userList.Select(x => new UserResponse()
            {
                Id = x.Id.ToString(),
                Email = x.Email,
                Name = x.UserName
            }).ToList();

            return ApiServiceResult<List<UserResponse>>.Success(userResponseList, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<UserResponse>> GetUserAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return ApiServiceResult<UserResponse>.Fail("Kullanici bulunamadi", HttpStatusCode.NotFound);
            }

            var userResponse = new UserResponse { Id = user.Id.ToString(), Email = user.Email, Name = user.UserName, City = user.City };

            return ApiServiceResult<UserResponse>.Success(userResponse, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<CreateUserResponse>> CreateUsersAsync(CreateUserRequest request)
        {
            var user = new AppUser
            {
                UserName = request.Email,
                Email = request.Email,
                City = request.City
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult<CreateUserResponse>.Fail(errorList, HttpStatusCode.BadRequest);
            }

            return ApiServiceResult<CreateUserResponse>.Success(new CreateUserResponse { UserId=user.Id,UserName=user.UserName}, HttpStatusCode.Created);

        }

        public async Task<ApiServiceResult> UpdateUsersAsync(UpdateUserRequest request)
        {

            var user = await userManager.FindByIdAsync(request.UserID.ToString());

            if (user == null)
            {
                return ApiServiceResult.Fail("Kullanıcı bulunamadi", HttpStatusCode.NotFound);
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

            return ApiServiceResult.Success( HttpStatusCode.OK);

        }

        public async Task<ApiServiceResult> DeleteUsersAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return ApiServiceResult.Fail("Kullanıcı Bulunamadi", HttpStatusCode.NotFound);
            }

            var result = await userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult.Fail(errorList, HttpStatusCode.BadRequest);
            }

            return ApiServiceResult.Success(HttpStatusCode.OK);
        }
    }
}
