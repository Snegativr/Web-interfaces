using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.User;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel user)
        {
            await _userService.AddUserAsync(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserModel user)
        {
            await _userService.UpdateUserAsync(id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}