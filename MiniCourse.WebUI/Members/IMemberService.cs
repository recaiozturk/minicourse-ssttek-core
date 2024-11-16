using MiniCourse.WebUI.Members.ViewModels;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.Members
{
    public interface IMemberService
    {
        Task<ServiceResult<MemberProfileViewModel>> GetProfileInfoAsync();
        Task<ServiceResult<MemberProfileUpdateViewModel>> GetProfileUpdateInfoAsync();
        Task<ServiceResult> UpdateMemberProfileAsync(MemberProfileUpdateViewModel model);
        Task<ServiceResult> ChangeMemberPasswordAsync(ChangePasswordViewModel model);
    }
}
