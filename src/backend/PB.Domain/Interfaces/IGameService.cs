using PB.Domain.Dto.GameDto;
using PB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Interfaces
{
    public interface IGameService
    {
        Task CreateGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(int gameId);
        Task<ICollection<ReadGameDto>> GetAllGameAsync();
        Task<ReadGameDto> GetGameById(int gameId);
    }
}
