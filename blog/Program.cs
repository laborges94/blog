using Blog;
using Microsoft.Data.SqlClient;

internal class Program
{
    private const string ConnectionString =
    "Server=localhost\\SQLEXPRESS;Database=Blog;Integrated Security=true;TrustServerCertificate=True;";
    //"Data Source=.\\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True;";

    private static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(ConnectionString);

        Database.Connection.Open();

        Load();

        Database.Connection.Close();

        Console.ReadKey();
    }

    static void Load()
    {
        Console.Clear();
    }
}