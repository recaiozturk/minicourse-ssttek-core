using AutoMapper;
using MiniCourse.Repository.Courses;
using MiniCourse.Service.Courses.DTOs;

namespace MiniCourse.Service.Courses
{
    public class CourseMappingProfile: Profile
    {
        public CourseMappingProfile()
        {
            //CreateMap<Course, CourseResponse>()
            //   .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            //CreateMap<CreateCourseRequest, Course>()
            //    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));

            //CreateMap<UpdateCourseRequest, Course>()
            //    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));

            //CreateMap<Course, CreateCourseResponse>()
            //    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Course, CourseResponse>();

            CreateMap<CreateCourseRequest, Course>();
            CreateMap<UpdateCourseRequest, Course>();

            CreateMap<Course, CreateCourseResponse>();
        }
    }
}
