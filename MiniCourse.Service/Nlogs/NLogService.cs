
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Courses;
using MiniCourse.Repository.NLogs;
using MiniCourse.Repository.Shared;
using MiniCourse.Service.Nlogs.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Nlogs
{
    public class NLogService(INLogrepository nLogrepository, IUnitOfWork unitOfWork) : INLogService
    {
        public async Task<ApiServiceResult<List<LogResponse>>> GetLogsAsync()
        {
            var logResponseList = await nLogrepository.GetAll()
                .Select(x => new LogResponse()
                {
                    Id = x.Id,
                    MachineName = x.MachineName,
                    Logged = x.Logged,
                    Level = x.Level,
                    Message = x.Message,
                    Logger = x.Logger,
                    Exception = x.Exception,
                }).ToListAsync();

            return ApiServiceResult<List<LogResponse>>.Success(logResponseList, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult> DeleteLogAsync(int logId)
        {

            var log = await nLogrepository.GetByIdAsync(logId);

            if (log == null)
            {
                return ApiServiceResult.Fail("Log bulunamadı", HttpStatusCode.NotFound);
            }

            nLogrepository.Remove(log);
            await unitOfWork.CommitAsync();

            return ApiServiceResult.Success(HttpStatusCode.OK);

        }
    }
}
