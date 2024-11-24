using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniCourse.Repository.Users;
using MiniCourse.Service.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniCourse.Service.Tokens
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        public async Task<TokenResponse> GenerateToken(AppUser user,UserManager<AppUser> userManager)
        {

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]));

            var claims = new List<Claim> {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName!),
                        new Claim(ClaimTypes.Email, user.Email!),
                        new Claim("token_id", Guid.NewGuid().ToString()),
            };

            var roles = await userManager.GetRolesAsync(user);
            var rolesClaim = roles.Select(role => new Claim(ClaimTypes.Role, role));
            claims.AddRange(rolesClaim);

            //userClaims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: configuration["AppSettings:ValidIssuer"],
                audience: configuration["AppSettings:ValidAudience"],
                claims: claims,

                expires: DateTime.Now.Add(TimeSpan.FromMinutes(500)),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenResponse(token);
        }
    }
}
