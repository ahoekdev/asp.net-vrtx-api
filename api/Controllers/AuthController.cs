using api.DTOs;
using api.Entities;
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
        public async Task<ActionResult<TokensDto>> Login(LoginDto dto)
        {
            var tokens = await authService.Login(dto);

            if (tokens is null)
            {
                return BadRequest("Incorrect credentials");
            }

            return tokens;
        }
    }
}