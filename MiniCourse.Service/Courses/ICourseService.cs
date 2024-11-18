﻿using MiniCourse.Service.Categories.DTOs;
using MiniCourse.Service.Courses.DTOs;
using MiniCourse.Service.Shared;

namespace MiniCourse.Service.Courses
{
    public interface ICourseService
    {
        Task<ApiServiceResult<List<CourseResponse>>> GetCoursesAsync();
        Task<ApiServiceResult<CoursesPagedResponse>> GetCoursesPagedAsync(int pageNumber, int pageSize);
        Task<ApiServiceResult<List<CourseResponse>>> GetCoursesByCategoryAsync(int catId);
        Task<ApiServiceResult<CourseResponse>> GetCourseAsync(int courseId);

        Task<ApiServiceResult<CreateCourseResponse>> CreateCourseAsync(CreateCourseRequest request);

        Task<ApiServiceResult> UpdateCourseAsync(UpdateCourseRequest request);

        Task<ApiServiceResult> DeleteCourseAsync(int courseId);
    }
}
