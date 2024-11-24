using Microsoft.AspNetCore.Identity;
using MiniCourse.Repository.Users;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Tokens
{
    public interface ITokenService
    {
        Task<TokenResponse> GenerateToken(AppUser user, UserManager<AppUser> userManager);
    }
}
