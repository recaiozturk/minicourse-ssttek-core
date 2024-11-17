using MiniCourse.WebUI.Auths.DTOs;
using MiniCourse.WebUI.Auths.ViewModels;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.Auths
{
    public interface IAuthService
    {
        Task<ServiceResult> SignInAsync(SignInViewModel model);
        Task<ServiceResult<SignInResponse>> GetClientCredentialToken();
        Task<ServiceResult> SignUpAsync(SignUpViewModel viewModel);

        Task<ServiceResult<string>> GetTokenAsync();

    }
}
