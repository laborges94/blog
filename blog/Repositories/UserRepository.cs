using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository(SqlConnection connection)
{
    private readonly SqlConnection _connection = connection;

    public IEnumerable<User> GetAllUsers() => _connection.GetAll<User>();

    public User GetUserById(int id) => _connection.Get<User>(id);

    public void CreateUser(User user) => _connection.Insert(user);

    public void UpdateUser(User user) => _connection.Update(user);

    public void DeleteUser(int id)
    {
        var user = _connection.Get<User>(id);
        if (user != null)
        _connection.Delete(user);
    }
}