using Microsoft.AspNetCore.Mvc;
using PB.Application.Service.Interfaces;
using PB.Domain.Entities;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("creategame")]
        public async Task<IActionResult> CreatGameAsync(Game game)
        {
            await _gameService.CreateGameAsync(game);

            return CreatedAtAction(nameof(GetGameByIdAsync), new { game.Id }, game);
        }

        [HttpGet("getallgames")]
        public async Task<IActionResult> GetAllGamesAsync()
        {
            var gameList = await _gameService.GetAllGameAsync();

            return Ok(gameList);
        }
        [HttpGet("getgamebyid/{id}")]
        public async Task<IActionResult> GetGameByIdAsync(int id)
        {
            var selectedGame = await _gameService.GetGameById(id);

            return Ok(selectedGame);
        }

        [HttpPatch("updategame")]
        public async Task<IActionResult> UpdateGameAsync(Game game)
        {
            await _gameService.UpdateGameAsync(game);

            return Ok(game);
        }

        [HttpDelete("deletegame/{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await _gameService.DeleteGameAsync(id);

            return NoContent();
        }

    }
}
