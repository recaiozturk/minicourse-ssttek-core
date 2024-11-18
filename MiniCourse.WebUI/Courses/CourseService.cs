using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MiniCourse.WebUI.Courses.DTOs;
using MiniCourse.WebUI.Courses.ViewModels;
using MiniCourse.WebUI.Shared;
using MiniCourse.WebUI.Util;
using MiniCourse.WebUI.ViewModels;

namespace MiniCourse.WebUI.Courses
{
    public class CourseService(HttpClient client, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory, IConfiguration configuration) : ICourseService
    {
        public async Task<ServiceResult<CourseUpdateViewModel>> GetCourseAsync(int courseId)
        {
            var address = $"/api/Courses/getcourse?courseId={courseId}";

            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<CourseUpdateViewModel>.Fail(problemDetail!.Detail!);
            }

            var course = await response.Content.ReadFromJsonAsync<CourseResponse>();

            var courseViewModel = new CourseUpdateViewModel
            {
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                CategoryId = course.CategoryId,
                Id = course.Id,
                CourseImage=course.CourseImage
            };

            return ServiceResult<CourseUpdateViewModel>.Success(courseViewModel);
        }

        public async Task<ServiceResult<List<CourseViewModel>>> GetCoursesAsync()
        {
            var address = "/api/Courses/getcourses";
            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<List<CourseViewModel>>.Fail(problemDetail!.Detail!);
            }

            var courses = await response.Content.ReadFromJsonAsync<List<CourseViewModel>>();

            return ServiceResult<List<CourseViewModel>>.Success(courses ?? new List<CourseViewModel>());
        }

        public async Task<ServiceResult<CoursesPagedModel>> PrepareListPageAsync(int pageNumber, int pageSize)
        {
            var address =  $"/api/Courses/getcoursespaged?pageNumber={pageNumber}&pageSize={pageSize}";
            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult < CoursesPagedModel>.Fail(problemDetail!.Detail!);
            }

            var coursesPagedResponse = await response.Content.ReadFromJsonAsync<CoursesPagedModel>();

            CoursesPagedModel coursesPagedModel = new CoursesPagedModel();

            coursesPagedModel.Courses = coursesPagedResponse.Courses;
            coursesPagedModel.TotalPages=coursesPagedResponse.TotalPages;

            return ServiceResult<CoursesPagedModel>.Success(coursesPagedModel);
        }

        public async Task<ServiceResult<HomeViewModel>> PrepareHomeListPageAsync(int catId)
        {
            var address = $"/api/Courses/getcoursesbycategory?catId={catId}";
            var response = await client.GetAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult<HomeViewModel>.Fail(problemDetail!.Detail!);
            }

            var coursesByCat = await response.Content.ReadFromJsonAsync<List<CourseViewModel>>();

            HomeViewModel homeModel= new HomeViewModel();
            homeModel.HomeCourses = coursesByCat;

            return ServiceResult<HomeViewModel>.Success(homeModel);
        }

        public async Task<ServiceResult> CreateCourseAsync(CourseCreateViewModel model)
        {
            if (model.ImageFile != null && model.ImageFile.Length > 0)
                model.CourseImage = ImageHelper.AddImageAsync(model.ImageFile).Result;

            var address = "/api/Courses/createcourse";

            var response = await client.PostAsJsonAsync(address, model);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var courseResponse = await response.Content.ReadFromJsonAsync<CourseCreateResponse>();

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = $"'{courseResponse!.Title}' kursu başarıyla oluşturuldu.";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> UpdateCourseAsync(CourseUpdateViewModel model)
        {
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                ImageHelper.DeleteOldImage( (await GetCourseAsync(model.Id)).Data.CourseImage);
                model.CourseImage = ImageHelper.AddImageAsync(model.ImageFile).Result;
            }

            var address = "/api/Courses/updatecourse";

            var response = await client.PutAsJsonAsync(address, model);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = "Kurs başarıyla güncellendi.";

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteCourseAsync(int courseId)
        {
            var address = $"/api/Courses/deletecourse?courseId={courseId}";

            var response = await client.DeleteAsync(address);

            if (!response.IsSuccessStatusCode)
            {
                var problemDetail = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return ServiceResult.Fail(problemDetail!.Detail!);
            }

            var tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
            tempData["SuccessMessage"] = "Kurs başarıyla silindi.";

            return ServiceResult.Success();
        }
    }
}
