using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PB.Domain.Dto.PostDto;
using PB.Domain.Entities;

namespace PB.Data.Profiles
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