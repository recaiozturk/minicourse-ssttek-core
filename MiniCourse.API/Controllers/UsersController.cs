using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Auths.DTOs;
using MiniCourse.Service.Users;

namespace MiniCourse.API.Controllers
{

    public class UsersController(IUserService userService) : CustomControllerBase
    {
        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await userService.GetUsersAsync();

            return CreateObjectResult(result);
        }
    }
}
