using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Courses;
using MiniCourse.Repository.Shared;
using MiniCourse.Service.Courses.DTOs;
using MiniCourse.Service.Shared;
using System.Net;

namespace MiniCourse.Service.Courses
{
    public class CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork,IMapper mapper) :ICourseService
    {
        public async Task<ApiServiceResult<List<CourseResponse>>> GetCoursesAsync()
        {
            var courses =  courseRepository.GetAll();

            var courseResponses = mapper.Map<List<CourseResponse>>(courses);

            return ApiServiceResult<List<CourseResponse>>.Success(courseResponses, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<List<CourseResponse>>> GetCoursesWithCategoryAsync()
        {
            var courses = await courseRepository.GetCoursesWithCategoryQuaaryble().ToListAsync();

            var courseResponses = mapper.Map<List<CourseResponse>>(courses);

            return ApiServiceResult<List<CourseResponse>>.Success(courseResponses, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<CoursesPagedResponse>> GetCoursesPagedAsync(int pageNumber, int pageSize,int catId)
        {

            IQueryable<Course> query = courseRepository.GetCoursesWithCategoryQuaaryble();

            if (catId != 0)
                query = query.Where(c => c.CategoryId == catId);

            var courses = await query.ToListAsync();

            var coursesPaged = courses.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var courseResponses = mapper.Map<List<CourseResponse>>(coursesPaged);

            CoursesPagedResponse response = new CoursesPagedResponse();
            response.Courses = courseResponses;
            response.TotalPages =  (int)Math.Ceiling(courses.Count() / (double)pageSize);

            string coursesTitle = "";
            if (catId == 0)
                coursesTitle = "Tüm Kurslar";
            else
                coursesTitle = response.Courses.First().Category.Name + " kategorisindeki ürünler";

            response.CourseTitle = coursesTitle;

            return ApiServiceResult<CoursesPagedResponse>.Success(response, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<List<CourseResponse>>> GetCoursesByCategoryAsync(int catId)
        {
            var coursesAll = await courseRepository.GetCoursesWithCategoryQuaaryble().ToListAsync();

            var coursesByCat = coursesAll.Where(c=>c.CategoryId==catId);

            var courseResponses = mapper.Map<List<CourseResponse>>(coursesByCat);

            return ApiServiceResult<List<CourseResponse>>.Success(courseResponses, HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult<CourseResponse>> GetCourseAsync(int courseId)
        {
            var course = await courseRepository.GetByIdWithCategoryAsync(courseId);

            if (course == null)
            {
                return ApiServiceResult<CourseResponse>.Fail("Kurs bulunamadı", HttpStatusCode.NotFound);
            }

            var courseResponse = mapper.Map<CourseResponse>(course);

            return ApiServiceResult<CourseResponse>.Success(courseResponse, HttpStatusCode.OK);
        }
        public async Task<ApiServiceResult<CourseResponse>> GetCourseWithCategoryAsync(int courseId)
        {
            var course = await courseRepository.GetByIdWithCategoryAsync(courseId);

            if (course == null)
            {
                return ApiServiceResult<CourseResponse>.Fail("Kurs bulunamadı", HttpStatusCode.NotFound);
            }

            var courseResponse = mapper.Map<CourseResponse>(course);

            return ApiServiceResult<CourseResponse>.Success(courseResponse, HttpStatusCode.OK);
        }

        

        public async Task<ApiServiceResult<CreateCourseResponse>> CreateCourseAsync(CreateCourseRequest request)
        {
            var course = mapper.Map<Course>(request);

            await courseRepository.AddAsync(course);
            await unitOfWork.CommitAsync();

            var response = mapper.Map<CreateCourseResponse>(course);

            return ApiServiceResult<CreateCourseResponse>.Success(response, HttpStatusCode.Created);
        }

        public async Task<ApiServiceResult> UpdateCourseAsync(UpdateCourseRequest request)
        {
            var course = await courseRepository.GetByIdAsync(request.Id);

            if (course == null)
            {
                return ApiServiceResult.Fail("Kurs bulunamadı", HttpStatusCode.NotFound);
            }

            if (request.CourseImage is null)
                request.CourseImage = course.CourseImage;

            mapper.Map(request, course);

            courseRepository.Update(course);
            await unitOfWork.CommitAsync();

            return ApiServiceResult.Success(HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult> DeleteCourseAsync(int courseId)
        {
            var course = await courseRepository.GetByIdAsync(courseId);

            if (course == null)
            {
                return ApiServiceResult.Fail("Kurs bulunamadı", HttpStatusCode.NotFound);
            }

            courseRepository.Remove(course);
            await unitOfWork.CommitAsync();

            return ApiServiceResult.Success(HttpStatusCode.OK);
        }
    }
}
