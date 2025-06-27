using api.Models;
using api.Models.DTOs;

namespace api.Services;

public static class UsersService
{
    static List<User> Users { get; }
    static int nextId = 3;
    static UsersService()
    {
        Users =
        [
            new User { Id = 1, Email = "user1@example.com" },
            new User { Id = 2, Email = "user2@example.com" }
        ];
    }

    public static List<User> GetAll() => Users;

    public static User? Get(int id) => Users.FirstOrDefault(p => p.Id == id);

    public static User Add(UserDto user)
    {
        var newUser = new User
        {
            Id = nextId++,
            Email = user.Email
        };

        Users.Add(newUser);

        return newUser;
    }

    public static User? Update(int id, User user)
    {
        var index = Users.FindIndex(p => p.Id == id);

        if (index == -1)
            return null;


        Users[index] = user;
        return user;
    }


    public static void Delete(int id)
    {
        var user = Get(id);

        if (user is null)
            return;

        Users.Remove(user);
    }
}