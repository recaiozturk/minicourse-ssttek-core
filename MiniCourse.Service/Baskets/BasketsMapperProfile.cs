using AutoMapper;
using MiniCourse.Repository.Baskets;
using MiniCourse.Service.Baskets.DTOs;

namespace MiniCourse.Service.Auths
{
    public class BasketsMapperProfile:Profile
    {
        public BasketsMapperProfile()
        {
            CreateMap<Basket,BasketResponse>();
        }
    }
}
