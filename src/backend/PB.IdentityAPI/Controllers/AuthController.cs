using PB.IdentityAPI.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static PB.IdentityAPI.Models.UserViewModels;
using Microsoft.EntityFrameworkCore;

namespace PB.IdentityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _singInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;

        public AuthController(SignInManager<IdentityUser> singInManager, UserManager<IdentityUser> userManager, TokenService tokenService)
        {
            _singInManager = singInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("singup")]
        public async Task<ActionResult> SingUp(UserRegister model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser 
            { 
                UserName = model.Email, 
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(await GenerateJwt(model.Email));
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLogin model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _singInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(await GenerateJwt(model.Email));
            }

            return BadRequest();

        }

        [HttpPost("reset-password-token")]
        public async Task<ActionResult> ResetPasswordRequestAsync(UserResetPasswordToken resetToken)
        {
            var identityUser = await _singInManager.UserManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == resetToken.Email.ToUpper());

            if (identityUser != null)
            {
                string resetCodeToken = await _singInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser);

                return Ok(resetCodeToken);
            }
            return BadRequest();

        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var users = _singInManager.UserManager.Users.ToList();

            List<string> userNames = new List<string>();
            foreach(var person in users)
            {
                userNames.Add(person.UserName);
            }

            return Ok(userNames);
        }

        private async Task<UserResponseLogin> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);


            var identityClaims = await _tokenService.GetClaimsUserAsync(claims, user, userRoles);

            var encodedToken = _tokenService.TokenCodifier(identityClaims);


            var response = _tokenService.TokenResponse(encodedToken, user, claims);


            return response;
        }
    }
}