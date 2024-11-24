using MiniCourse.Service.Nlogs.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Nlogs
{
    public interface INlogService
    {
        Task<ApiServiceResult> CreateLogAsync(ExceptionRequest exceptionRequest);
    }
}
