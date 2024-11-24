using MiniCourse.WebUI.NLogs.ViewModels;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.NLogs
{
    public interface INLogService
    {
        Task<ServiceResult> LogErrorToApi(ExceptionViewModel exceptionModel);
    }
}
