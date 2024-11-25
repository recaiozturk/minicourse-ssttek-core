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


            //HttpResponseMessage message;


            //try
            //{
            //    message = await client.PostAsJsonAsync(address, errorDto);
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}


            //burdayiz

            var response = await client.PostAsJsonAsync(address, errorDto);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<ErrorLogDto>.Fail(problemDetail!.Detail!);
            }

            return ServiceResult<ErrorLogDto>.Success(errorDto);
        }
    }
}
