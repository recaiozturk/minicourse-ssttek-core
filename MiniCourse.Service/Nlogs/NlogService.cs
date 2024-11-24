using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MiniCourse.Service.Members.DTOs;
using MiniCourse.Service.Nlogs.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Nlogs
{
    public class NlogService(ILogger<NlogService> logger) :INlogService
    {
        public async Task<ApiServiceResult> CreateLogAsync(ExceptionRequest exceptionRequest)
        {
            logger.LogError(exceptionRequest.Exception,exceptionRequest.Exception.Message);

            return ApiServiceResult.Success(HttpStatusCode.OK);

        }
    }
}
