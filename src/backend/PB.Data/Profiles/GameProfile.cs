using AutoMapper;
using PB.Domain.Dto.GameDto;
using PB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PB.Data.Profiles
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
