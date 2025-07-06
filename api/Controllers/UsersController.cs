using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Models;
using api.Entities;
using Microsoft.AspNetCore.Authorization;
using api.Enums;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(UserService userService) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            return Ok(await userService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            try
            {
                return Ok(await userService.GetUserByIdAsync(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
