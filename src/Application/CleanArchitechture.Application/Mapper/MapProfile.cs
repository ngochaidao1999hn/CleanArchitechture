using AutoMapper;
using CleanArchitechture.Application.Dtos.User;
using CleanArchitechture.Domain.Entities;

namespace CleanArchitechture.Application.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, ListUserDto>();
            CreateMap<User,GetUserDto>();
        }
    }
}
