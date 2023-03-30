using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PB.Application.Dto.GameDto;
using PB.Application.Service.Interfaces;
using PB.Data;
using PB.Domain.Entities;

namespace PB.Application.Service
{
    public class GameService : IGameService
    {
        private readonly SocialMediaDbContext _context;
        private readonly IMapper _mapper;

        public GameService(SocialMediaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateGameAsync(Game game)
        {
            if (game == null)
            {
                throw new Exception("O objeto é nulo, confira se foi preenchido corretamente.");
            }
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ReadGameDto>> GetAllGameAsync()
        {
            var gameList = await _context.Games.ToListAsync();
            var gameListDto = _mapper.Map<ICollection<ReadGameDto>>(gameList);


            return gameListDto;
        }
        public async Task<ReadGameDto> GetGameById(int gameId)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId);
            var readDto = _mapper.Map<ReadGameDto>(game);
            return readDto;
        }

        public async Task UpdateGameAsync(Game game)
        {
            var oldGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == game.Id);
            _mapper.Map(game, oldGame);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteGameAsync(int gameId)
        {

            var deletedGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId);
            if (deletedGame == null)
            {
                throw new Exception($"{gameId} não existe");
            }
            _context.Games.Remove(deletedGame);
            await _context.SaveChangesAsync();

        }
    }
}
