using blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

internal class Program
{
    private const string ConnectionString =
    "Server=(localdb)\\MSSQLLocalDB;Database=Blog;Integrated Security=true;";

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ReadUsers();
    }

    public static void ReadUsers()
    {
        using var connection = new SqlConnection(ConnectionString);

        var user = connection.GetAll<User>();

        foreach (var u in user)
            Console.WriteLine($"{u.Id} - {u.Name} - {u.Email}");
    }
}

