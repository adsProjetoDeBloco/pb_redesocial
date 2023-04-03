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

        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser(User User)
        {
            await _userService.AddUser(User);

            return CreatedAtAction(nameof(GetUserById), new { Id = User.Id }, User);
        }

        [HttpPost("addgametouser/{gameId}/{userId}")]
        public async Task<IActionResult> AddGameToUser(int gameId, int userId)
        {

            await _userService.AddGameToUser(gameId, userId);

            return Ok();
        }

        [HttpPost("addfollower")]
        public async Task<IActionResult> AddFollowerToUser(int userId, int followerId)
        {
            await _userService.AddFollowerToUser(followerId, userId);

            return Ok();
        }

        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            return Ok(users);
        }        
        
        [HttpGet("getuserbyid/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            return Ok(user);
        }
        [HttpGet("getuserbyemail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);

            return Ok(user);
        }
        [HttpDelete("deleteuser/{id}")]
        public async Task<IActionResult> DelteUser(int id)
        {
            await _userService.DeleteUser(id);

            return NoContent();
        }

    }
}