using PB.Domain.Dto.ComentDto;
using PB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Domain.Interfaces
{
    public interface IComentService
    {
        Task CreateComentAsync(Coment coment);
        Task UpdateComentAsync(Game game);
        Task DeleteComentAsync(int gameId);
        Task<ICollection<ReadComentDto>> GetAllComentAsync();
        Task<ReadGameDto> GetComentById(int gameId);
    }
}