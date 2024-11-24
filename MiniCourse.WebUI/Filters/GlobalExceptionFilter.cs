using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.NLogs;
using MiniCourse.WebUI.NLogs.ViewModels;

namespace MiniCourse.WebUI.Filters
{
    public class GlobalExceptionFilter(INLogService nLogService,ILogger<GlobalExceptionFilter> logger) : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            logger.LogError(exception, "Hata!");
            nLogService.LogErrorToApi(new ExceptionViewModel { Exception = exception });
            var result = new RedirectToActionResult("Error", "Home", new { message = exception.Message });

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
