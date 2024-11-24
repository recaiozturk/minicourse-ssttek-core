using Azure.Core;
using Microsoft.Extensions.Caching.Memory;
using MiniCourse.WebUI.Auths;
using NuGet.Common;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MiniCourse.WebUI.Handlers
{
    public class ClientCredentialHandler(IMemoryCache memoryCache, IAuthService authService, IHttpContextAccessor httpContextAccessor) : DelegatingHandler
    {
        private const string TokenCacheKey = "tokenCacheKey";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!memoryCache.TryGetValue(TokenCacheKey, out object? token))
            {
                var result = await authService.GetClientCredentialToken();

                if (result.AnyError)
                {
                    throw new Exception(result.GetFirstError);
                }

                token = result.Data!.AccessToken;
                memoryCache.Set(TokenCacheKey, token, TimeSpan.FromMinutes(295));
            }


            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token!.ToString());




            return await base.SendAsync(request, cancellationToken);
        }

    }
}
