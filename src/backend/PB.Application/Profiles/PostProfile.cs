
using AutoMapper;
using PB.Application.Dto.PostDto;
using PB.Application.Dto.UserDto;
using PB.Domain.Entities;

namespace PB.Application.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<ReadPostDto, Post>();
            CreateMap<Post, ReadPostDto>();
            CreateMap<CreatPostDto, Post>();
            CreateMap<Post, CreatPostDto>();
        }
    }
}