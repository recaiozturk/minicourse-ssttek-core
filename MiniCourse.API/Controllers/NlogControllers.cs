using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Members.DTOs;
using MiniCourse.Service.Nlogs;
using MiniCourse.Service.Nlogs.DTOs;

namespace MiniCourse.API.Controllers
{
    public class NlogControllers(INlogService nlogService) : CustomControllerBase
    {
        [HttpPost("save-error-log")]
        public async Task<IActionResult> CreateLogAsync(ExceptionRequest exceptionRequest)
        {
           
            var result = await nlogService.CreateLogAsync(exceptionRequest);
            return CreateObjectResult(result);
        }
    }
}
