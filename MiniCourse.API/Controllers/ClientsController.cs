
using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Auths;
using MiniCourse.Service.Shared;

namespace MiniCourse.API.Controllers
{
    public class ClientsController(IAuthService authService) : CustomControllerBase
    {
        [HttpPost("signin-client-credential")]
        public async Task<IActionResult> SignInClientCredentialAsync(SignInClientCredentialRequest request)
        {
            var result = await authService.SignInClientCredentialAsync(request);

            return CreateObjectResult(result);
        }
    }
}
