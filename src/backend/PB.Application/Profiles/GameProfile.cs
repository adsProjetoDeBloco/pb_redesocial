using AutoMapper;
using PB.Application.Dto.GameDto;
using PB.Domain.Entities;


namespace PB.Application.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile() 
        {
            CreateMap<ReadGameDto, Game>();
            CreateMap<Game, ReadGameDto>();
        
        }
    }
}
