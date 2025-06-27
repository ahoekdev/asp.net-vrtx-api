using api.Models;

namespace api.Services;

public static class UsersService
{
    static List<User> Users { get; }
    // static int nextId = 3;
    static UsersService()
    {
        Users =
        [
            new User { Id = 1, Name = "User 1", Email = "user1@example.com" },
            new User { Id = 2, Name = "User 2", Email = "user2@example.com" }
        ];
    }

    public static List<User> GetAll() => Users;

    // public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    // public static void Add(Pizza pizza)
    // {
    //     pizza.Id = nextId++;
    //     Pizzas.Add(pizza);
    // }

    // public static void Delete(int id)
    // {
    //     var pizza = Get(id);
    //     if(pizza is null)
    //         return;

    //     Pizzas.Remove(pizza);
    // }

    // public static void Update(Pizza pizza)
    // {
    //     var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
    //     if(index == -1)
    //         return;

    //     Pizzas[index] = pizza;
    // }
}