using MiniCourse.Service.Members.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Members
{
    public interface IMemberService
    {
        Task<ApiServiceResult<MemberProfileResult>> GetUserProfileAsync(string userId);
        Task<ApiServiceResult> UpdateMemberProfileAsync(UpdateMemberProfileRequest request);
        Task<ApiServiceResult> ChangeMemberPasswordAsync(ChangeMemberPasswordRequest request);

    }
}
