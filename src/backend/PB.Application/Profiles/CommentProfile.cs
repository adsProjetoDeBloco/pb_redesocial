using AutoMapper;
using PB.Application.Dto.CommentDto;
using PB.Domain.Entities;

namespace PB.Application.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile() 
        {
            CreateMap<CreateCommentDto, Comment>();
            CreateMap<Comment, CreateCommentDto>();
            CreateMap<ReadCommentDto, Comment>();
            CreateMap<Comment, ReadCommentDto>();
        
        }
    }
}
