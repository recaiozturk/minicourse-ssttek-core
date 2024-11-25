using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MiniCourse.WebUI.Auths.DTOs;
using MiniCourse.WebUI.Auths.ViewModels;
using MiniCourse.WebUI.Shared;
using System.Security.Claims;

namespace MiniCourse.WebUI.Auths
{
    public class AuthService(HttpClient client,IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) :IAuthService
    {
        public async Task<ServiceResult> SignInAsync(SignInViewModel model)
        {
            var address = "/api/Auth/sign-in";

            var response = await client.PostAsJsonAsync<SignInViewModel>(address, model);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tokenResponse = await response.Content.ReadFromJsonAsync<SignInResponse>();


            JsonWebTokenHandler tokenHandler = new JsonWebTokenHandler();

            var jwtAsDecoded = tokenHandler.ReadJsonWebToken(tokenResponse!.AccessToken.ToString());


            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(jwtAsDecoded.Claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


            AuthenticationProperties authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };

            var accessToken = new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.AccessToken,
                Value = tokenResponse.AccessToken
            };

            authenticationProperties.StoreTokens([accessToken]);

            await httpContextAccessor.HttpContext!.SignInAsync(claimsPrincipal, authenticationProperties);

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> SignUpAsync(SignUpViewModel viewModel)
        {
            var address = "/api/Auth/sign-up";

            var response = await client.PostAsJsonAsync<SignUpViewModel>(address, viewModel);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = "Kaydınız Başarili şekilde oluştu";

            return ServiceResult.Success();

        }

        public async Task<ServiceResult<SignInResponse>> GetClientCredentialToken()
        {  
            var clientCredentialTokenRequest = new ClientCredentialTokenRequest(
                configuration.GetSection("Clients")["ClientId"]!,
                configuration.GetSection("Clients")["ClientSecret"]!);

            var tokenAddress = "api/Clients/signin-client-credential";


            var responseAsToken =
                await client.PostAsJsonAsync<ClientCredentialTokenRequest>(tokenAddress,
                    clientCredentialTokenRequest);


            if (!responseAsToken.IsSuccessStatusCode)
            {
                return ServiceResult<SignInResponse>.Fail("client credential token alınamadı");
            }

            var signResponse = await responseAsToken.Content.ReadFromJsonAsync<SignInResponse>();


            return ServiceResult<SignInResponse>.Success(signResponse!);
        }
    }
}
