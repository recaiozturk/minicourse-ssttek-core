using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniCourse.Repository.Users;
using MiniCourse.Service.Auths.DTOs;
using MiniCourse.Service.Shared;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MiniCourse.Service.Auths
{
    public class AuthService(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager, IConfiguration configuration,IMapper mapper) :IAuthService
    {
        public async Task<ApiServiceResult<TokenResponse>> SignInAsync(SignInRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return ApiServiceResult<TokenResponse>.Fail("Email veya şifre yanlış", HttpStatusCode.BadRequest);
            }

            var result = await userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                return ApiServiceResult<TokenResponse>.Fail("Email veya şifre yanlış", HttpStatusCode.BadRequest);
            }

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim("token_id", Guid.NewGuid().ToString())
            };

            var roles = await userManager.GetRolesAsync(user);

            userClaims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var claimListAsScope = await userManager.GetClaimsAsync(user);

            userClaims.AddRange(claimListAsScope);

            JwtSecurityToken newToken = new JwtSecurityToken(
                issuer: configuration["TokenOption:Issuer"],
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(300),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOption:SymmetricKey"]!)),
                    SecurityAlgorithms.HmacSha256)
            );

            var accessTokenAsString = new JwtSecurityTokenHandler().WriteToken(newToken);

            return ApiServiceResult<TokenResponse>.Success(new TokenResponse(accessTokenAsString), HttpStatusCode.OK);
        }


        public Task<ApiServiceResult<TokenResponse>> SignInClientCredentialAsync(SignInClientCredentialRequest request)
        {
            var clientId = configuration.GetSection("Clients")["ClientId"];
            var clientSecret = configuration.GetSection("Clients")["ClientSecret"];


            if (request.ClientId != clientId || request!.ClientSecret != request.ClientSecret)
            {
                return Task.FromResult(ApiServiceResult<TokenResponse>.Fail("clientId veya clientsecret hatalı",
                    HttpStatusCode.BadRequest));
            }


            var clientClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, clientId),
                new Claim("token_id", Guid.NewGuid().ToString())
            };


            JwtSecurityToken newToken = new JwtSecurityToken(
                issuer: configuration["TokenOption:Issuer"],
                claims: clientClaims,
                expires: DateTime.Now.AddMinutes(300),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOption:SymmetricKey"]!)),
                    SecurityAlgorithms.HmacSha256)
            );


            var accessTokenAsString = new JwtSecurityTokenHandler().WriteToken(newToken);
            return Task.FromResult(
                ApiServiceResult<TokenResponse>.Success(new TokenResponse(accessTokenAsString), HttpStatusCode.OK));
        }

        public async Task<ApiServiceResult> SignUpAsync(SignUpRequest request)
        {
            var appUser = mapper.Map<AppUser>(request);


            var result = await userManager.CreateAsync(appUser, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult.Fail(errors,HttpStatusCode.BadRequest);
            }

            string defaultRole = "User";
            var roleExists = await roleManager.RoleExistsAsync(defaultRole);

            if (!roleExists)
            {
                var newRoleForUser = new IdentityRole(defaultRole);
                await roleManager.CreateAsync(new AppRole() { Name = defaultRole });
            }

            await userManager.AddToRoleAsync(appUser, defaultRole);

            return ApiServiceResult.Success(HttpStatusCode.OK);
        }


    }
}
