
using AutoMapper;
using PB.Application.Dto.PostDto;
using PB.Application.Dto.UserDto;
using PB.Domain.Entities;

namespace PB.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ReadUserDto, User>();
            CreateMap<User, ReadUserDto>();
        }
    }
}