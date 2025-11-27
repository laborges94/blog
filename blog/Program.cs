using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

internal class Program
{
    private const string ConnectionString =
    "Server=localhost\\SQLEXPRESS;Database=Blog;Integrated Security=true;TrustServerCertificate=True;";
    //"Data Source=.\\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True;";

    private static void Main(string[] args)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();

        ReadUsers(connection);

        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var UserRepository = new UserRepository(connection);
        var users = UserRepository.GetAllUsers();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id} - {user.Name} - {user.Email}");
        }
    }

    public static void ReadUser(SqlConnection connection)
    {
        var UserRepository = new UserRepository(connection);
        var user = UserRepository.GetUserById(1);
        Console.WriteLine($"{user.Id} - {user.Name} - {user.Email}");
    }

    public static void CreateUser(SqlConnection connection)
    {
        var user = new User
        {
            Name = "Leandro Silva",
            Email = "leandro@example.com",
            PasswordHash = "hashedpassword",
            Bio = "Developer",
            Image = "https://example.com/image.jpg",
            Slug = "leandro-silva"
        };

        var UserRepository = new UserRepository(connection);

        UserRepository.CreateUser(user);

        Console.WriteLine($"User created.");
    }

    public static void UpdateUser(SqlConnection connection)
    {
        var UserRepository = new UserRepository(connection);

        var user = UserRepository.GetUserById(1);
        user.Name = "Zé da Silva";

        UserRepository.UpdateUser(user);

        Console.WriteLine($"User updated.");
    }

    public static void DeleteUser(SqlConnection connection)
    {
        var UserRepository = new UserRepository(connection);

        var user = UserRepository.GetUserById(1);
        UserRepository.DeleteUser(user.Id);

        Console.WriteLine($"User deleted.");
    }
}