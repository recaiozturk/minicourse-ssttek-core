using AutoMapper;
using MiniCourse.Repository.Courses;
using MiniCourse.Service.Courses.DTOs;

namespace MiniCourse.Service.Courses
{
    public class CourseMappingProfile: Profile
    {
        public CourseMappingProfile()
        {

            CreateMap<Course, CourseResponse>();

            CreateMap<CreateCourseRequest, Course>();
            CreateMap<UpdateCourseRequest, Course>();

            CreateMap<Course, CreateCourseResponse>();

            CreateMap<Course, CourseSearchResponse>();

        }
    }
}
