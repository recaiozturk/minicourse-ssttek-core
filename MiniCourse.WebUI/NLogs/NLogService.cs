using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Courses.DTOs;
using MiniCourse.WebUI.Courses.ViewModels;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.Util;
using MiniCourse.WebUI.NLogs.ViewModels;
using System;
using MiniCourse.WebUI.Roles.ViewModels;
using MiniCourse.WebUI.NLogs.DTOs;

namespace MiniCourse.WebUI.NLogs
{
    public class NLogService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) : INLogService
    {
        public async Task<ServiceResult<ErrorLogDto>> LogErrorToApi(ExceptionViewModel exceptionModel)
        {

            var address = "/api/nlog/save-error-log";


            var errorDto = new ErrorLogDto
            {
                Message = exceptionModel.Exception.Message,
                StackTrace = exceptionModel.Exception.StackTrace,
                Source = exceptionModel.Exception.Source,
                LoggedAt=DateTime.Now,
            };

            var response = await client.PostAsJsonAsync(address, errorDto);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<ErrorLogDto>.Fail(problemDetail!.Detail!);
            }

            return ServiceResult<ErrorLogDto>.Success(errorDto);
        }

        public async Task<ServiceResult<List<LogViewModel>>> GetLogsAsync()
        {
            var address = "/api/nlog/get-logs";
            var response = await client.GetAsync(address);


            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<List<LogViewModel>>.Fail(problemDetail!.Detail!);
            }

            var logs = await response.Content.ReadFromJsonAsync<List<LogViewModel>>();

            return ServiceResult<List<LogViewModel>>.Success(logs);

        }

        public async Task<ServiceResult> DeleteLogAsync(int logId)
        {
            var address = $"/api/NLog/delete-log?logId={logId}";

            var response = await client.DeleteAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = "Log başarıyla silindi.";

            return ServiceResult.Success();
        }


    }
}
