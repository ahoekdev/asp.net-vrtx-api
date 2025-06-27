using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

using api.Models;

[ApiController]
[Route("[controller]")]
public class UsersController(ILogger<UsersController> logger) : ControllerBase
{
    private static readonly User[] Users =
    [
        new User { Id = 1, Name = "User 1", Email = "user1@example.com" },
        new User { Id = 2, Name = "User 2", Email = "user2@example.com" },
        new User { Id = 3, Name = "User 3", Email = "user3@example.com" },
        new User { Id = 4, Name = "User 4", Email = "user4@example.com" },
        new User { Id = 5, Name = "User 5", Email = "user5@example.com" }
    ];

    [HttpGet(Name = "GetUsers")]
    public IEnumerable<User> Get()
    {
        logger.LogInformation("Fetching users");
        return Users;
    }
}
