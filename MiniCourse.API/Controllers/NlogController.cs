using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Nlogs;
using MiniCourse.Service.Nlogs.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.API.Controllers
{
    [Authorize]
    public class NlogController(INLogService logService, ILogger<NlogController> logger) : CustomControllerBase
    {
        [HttpPost("save-error-log")]
        public async Task<IActionResult> CreateLogAsync(ExceptionRequest exceptionRequest)
        {
            //not :service ile kullandıgmızda Nlog database e eklme yapmiyor  - direk burda kullandim

            var fakeException = new CustomException(
                exceptionRequest.Message,
                exceptionRequest.Source,
                exceptionRequest.StackTrace
            );

            logger.LogError(fakeException, exceptionRequest.Message);

            return Ok(HttpStatusCode.OK);
        }


        [HttpGet("get-logs")]
        public async Task<IActionResult> GetLogsAsync()
        {
            var result = await logService.GetLogsAsync();
            return CreateObjectResult(result);
        }

        [HttpDelete("delete-log")]
        public async Task<IActionResult> DeleteLogAsync(int logId)
        {
            var result = await logService.DeleteLogAsync(logId);
            return CreateObjectResult(result);
        }
    }
}
