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

        connection.Close();

        Console.ReadKey();
    }
}