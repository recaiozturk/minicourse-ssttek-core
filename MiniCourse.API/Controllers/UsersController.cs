using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Users;
using MiniCourse.Service.Users.DTOs;

namespace MiniCourse.API.Controllers
{
    [Authorize]
    public class UsersController(IUserService userService) : CustomControllerBase
    {
        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await userService.GetUsersAsync();
            return CreateObjectResult(result);
        }

        [HttpGet("get-user")]
        public async Task<IActionResult> GetUserAsync(string userId)
        {
            var result = await userService.GetUserAsync(userId);
            return CreateObjectResult(result);
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUsersAsync(CreateUserRequest request)
        {
            var result = await userService.CreateUsersAsync(request);
            return CreateObjectResult(result);
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUsersAsync(UpdateUserRequest request)
        {
            var result = await userService.UpdateUsersAsync(request);
            return CreateObjectResult(result);
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUsersAsync(string userId)
        {
            var result = await userService.DeleteUsersAsync(userId);
            return CreateObjectResult(result);
        }
        
    }
}
