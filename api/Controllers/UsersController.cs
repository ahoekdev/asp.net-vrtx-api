using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

using api.Models;
using api.Models.DTOs;
using api.Services;

[ApiController]
[Route("[controller]")]
public class UsersController(ILogger<UsersController> logger) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        logger.LogInformation("Fetching users");
        return Ok(UsersService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UsersService.Get(id);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> Post(UserDto user)
    {

        var newUser = UsersService.Add(user);
        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}")]
    public ActionResult<User> Put(int id, User user)
    {
        if (user.Id != id)
        {
            return BadRequest("User ID mismatch");
        }

        var updatedUser = UsersService.Update(id, user);

        if (updatedUser is null)
        {
            return NotFound();
        }

        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = UsersService.Get(id);

        if (user is null)
        {
            return NotFound();
        }

        UsersService.Delete(id);

        return NoContent();
    }
}