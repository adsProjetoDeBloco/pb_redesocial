using Microsoft.AspNetCore.Mvc;
using PB.Application.Service.Interfaces;
using PB.Domain.Entities;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser(User User)
        {
            await _userService.AddUser(User);

            return Ok(User);
        }

        [HttpPost("add-game-to-user/{gameId}/{userId}")]
        public async Task<IActionResult> AddGameToUser(int gameId, int userId)
        {

            await _userService.AddGameToUser(gameId, userId);

            return Ok();
        }

        [HttpPost("add-follower")]
        public async Task<IActionResult> AddFollowerToUser(int userId, int followerId)
        {
            await _userService.AddFollowerToUser(followerId, userId);

            return Ok();
        }

        [HttpGet("gett-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            return Ok(users);
        }

    }
}