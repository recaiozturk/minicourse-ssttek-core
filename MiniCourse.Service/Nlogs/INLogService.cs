using MiniCourse.Service.Nlogs.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Nlogs
{
    public interface INLogService
    {
        Task<ApiServiceResult<List<LogResponse>>> GetLogsAsync();
        Task<ApiServiceResult> DeleteLogAsync(int logId);
    }
}
