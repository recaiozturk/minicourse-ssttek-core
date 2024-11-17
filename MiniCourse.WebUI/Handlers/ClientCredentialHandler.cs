using Microsoft.Extensions.Caching.Memory;
using MiniCourse.WebUI.Auths;
using System.Net.Http.Headers;

namespace MiniCourse.WebUI.Handlers
{
    public class ClientCredentialHandler(IMemoryCache memoryCache, IAuthService authService) : DelegatingHandler
    {
        private const string TokenCacheKey = "tokenCacheKey";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!memoryCache.TryGetValue(TokenCacheKey, out object? token))
            {
                //clientler için credential
                var resultCredential = await authService.GetClientCredentialToken();

                var accecTokenResult = await authService.GetTokenAsync();

                if(resultCredential.AnyError)
                {
                    throw new Exception(accecTokenResult.GetFirstError);
                }
                else if (accecTokenResult.AnyError)
                {
                    throw new Exception(accecTokenResult.GetFirstError);
                }

                //tokenCredential = resultCredential.Data!.AccessToken;
                token = accecTokenResult.Data!;
                memoryCache.Set(TokenCacheKey, token, TimeSpan.FromMinutes(295));
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token!.ToString());

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
