using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

using api.Models;

[ApiController]
[Route("[controller]")]
public class UsersController(ILogger<UsersController> logger) : ControllerBase
{
    private static readonly User[] Users =
    [
        new User { Name = "User 1", Email = "user1@example.com" },
        new User { Name = "User 2", Email = "user2@example.com" },
        new User { Name = "User 3", Email = "user3@example.com" },
        new User { Name = "User 4", Email = "user4@example.com" },
        new User { Name = "User 5", Email = "user5@example.com" }
    ];

    [HttpGet(Name = "GetUsers")]
    public IEnumerable<User> Get()
    {
        logger.LogInformation("Fetching users");
        return Users;
    }
}
