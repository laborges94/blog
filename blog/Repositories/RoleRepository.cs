using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class RoleRepository(SqlConnection connection)
{
    private readonly SqlConnection _connection = connection;

    public IEnumerable<Role> GetAllRoles() => _connection.GetAll<Role>();

    public Role GetRoleById(int id) => _connection.Get<Role>(id);

    public void CreateRole(Role role) => _connection.Insert(role);

    public void UpdateRole(Role role) => _connection.Update(role);

    public void DeleteRole(int id)
    {
        var role = _connection.Get<Role>(id);
        if (role != null)
            _connection.Delete(role);
    }
}