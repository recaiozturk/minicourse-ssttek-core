using MiniCourse.WebUI.NLogs.DTOs;
using MiniCourse.WebUI.NLogs.ViewModels;
using MiniCourse.WebUI.Shared;

namespace MiniCourse.WebUI.NLogs
{
    public interface INLogService
    {
        Task<ServiceResult<ErrorLogDto>> LogErrorToApi(ExceptionViewModel exceptionModel);
        Task<ServiceResult<List<LogViewModel>>> GetLogsAsync();
        Task<ServiceResult> DeleteLogAsync(int logId);
    }
}
