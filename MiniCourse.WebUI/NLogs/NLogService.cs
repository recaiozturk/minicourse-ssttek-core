using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Courses.DTOs;
using MiniCourse.WebUI.Courses.ViewModels;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.Util;
using MiniCourse.WebUI.NLogs.ViewModels;
using System;

namespace MiniCourse.WebUI.NLogs
{
    public class NLogService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) :INLogService
    {
        public async Task<ServiceResult> LogErrorToApi(ExceptionViewModel exceptionModel)
        {

            var address = "/api/Nlog/save-error-log";

            //var response = await client.PostAsJsonAsync(address, exceptionModel);

            //
            try
            {
                var response2 = await client.PostAsJsonAsync(address, exceptionModel);
            }
            catch (Exception e)
            {
                //!!!! Exception i serialize etmiyor paketleyip gönderrrrr
                throw;
            }
            //

            ErrorLogDto errorDto = new ErrorLogDto();

            //errorDto.Message = exceptionModel.Exception.Message
            //errorDto.Source=exceptionModel.Exception.Source,
            //StackTrace = ex
            //Source = ex.Source

            var response = await client.PostAsJsonAsync(address, exceptionModel);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            return ServiceResult.Success();
        }
    }
}
