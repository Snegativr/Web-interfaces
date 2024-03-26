using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApplication3.Models.User;
using WebApplication3.Services;
namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            var user = new UserModel
            {
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                Password = model.Password,
                LastLoginDate = model.LastLoginDate,
                FailedLoginAttempts = model.FailedLoginAttempts,
            };

            await _authService.RegisterAsync(user);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var user = await _authService.AuthAsync(model.Email, model.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(user);
        }
    }
}
