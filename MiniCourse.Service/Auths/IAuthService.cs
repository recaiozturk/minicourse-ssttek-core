using MiniCourse.Service.Auths.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Auths
{
    public interface IAuthService
    {
        Task<ApiServiceResult<TokenResponse>> SignInAsync(SignInRequest request);
        Task<ApiServiceResult<TokenResponse>> SignInClientCredentialAsync(SignInClientCredentialRequest request);
        Task<ApiServiceResult> SignUpAsync(SignUpRequest request);
    }
}
