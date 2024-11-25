using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Members;
using MiniCourse.Service.Members.DTOs;

namespace MiniCourse.API.Controllers
{
    [Authorize]
    public class MembersController(IMemberService memberService) : CustomControllerBase
    {
        [HttpGet("get-user-profile")]
        public async Task<IActionResult> GetUserProfileAsync(string userId)
        {
            var result = await memberService.GetUserProfileAsync(userId);
            return CreateObjectResult(result);
        }

        [HttpPut("update-member")]
        public async Task<IActionResult> UpdateMemberProfileAsync(UpdateMemberProfileRequest request)
        {
            var result = await memberService.UpdateMemberProfileAsync(request);
            return CreateObjectResult(result);
        }


        [HttpPut("change-password")]
        public async Task<IActionResult> ChangeMemberPasswordAsync(ChangeMemberPasswordRequest request)
        {
            var result = await memberService.ChangeMemberPasswordAsync(request);
            return CreateObjectResult(result);
        }     
    }
}
