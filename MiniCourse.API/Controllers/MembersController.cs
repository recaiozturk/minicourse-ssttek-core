using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Members;
using MiniCourse.Service.Members.DTOs;
using MiniCourse.Service.Roles.DTOs;

namespace MiniCourse.API.Controllers
{
    public class MembersController(IMemberService memberService) : CustomControllerBase
    {
        [HttpGet("getuserprofile")]
        public async Task<IActionResult> GetUserProfileAsync(string userId)
        {
            var result = await memberService.GetUserProfileAsync(userId);
            return CreateObjectResult(result);
        }

        [HttpPut("updatemember")]
        public async Task<IActionResult> UpdateMemberProfileAsync(UpdateMemberProfileRequest request)
        {
            var result = await memberService.UpdateMemberProfileAsync(request);
            return CreateObjectResult(result);
        }


        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangeMemberPasswordAsync(ChangeMemberPasswordRequest request)
        {
            var result = await memberService.ChangeMemberPasswordAsync(request);
            return CreateObjectResult(result);
        }     
    }
}
