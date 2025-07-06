using api.Entities;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            return Ok(await authService.Register(registerDto));
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            var token = await authService.Login(dto);

            if (token is null)
            {
                return BadRequest("Incorrect credentials");
            }

            return token;
        }
    }
}