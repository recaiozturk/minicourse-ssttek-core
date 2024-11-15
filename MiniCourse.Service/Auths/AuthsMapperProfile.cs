using AutoMapper;
using MiniCourse.Repository.Users;
using MiniCourse.Service.Auths.DTOs;

namespace MiniCourse.Service.Auths
{
    public class AuthsMapperProfile:Profile
    {
        public AuthsMapperProfile()
        {
            CreateMap<SignUpRequest,AppUser>();
        }
    }
}
