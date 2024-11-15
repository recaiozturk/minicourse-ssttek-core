using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Users;
using MiniCourse.Service.Shared;
using MiniCourse.Service.Users.DTOs;
using System.Net;

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
    }
}
