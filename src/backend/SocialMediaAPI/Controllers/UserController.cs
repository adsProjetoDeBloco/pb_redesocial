using Microsoft.AspNetCore.Mvc;
using PB.Domain.Entities;
using PB.Domain.Interfaces;

namespace SocialMediaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost("add-follower")]
        public async Task<IActionResult> AddFollowerToUser(int followerId, int userId)
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
