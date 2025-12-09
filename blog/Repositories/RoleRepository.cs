using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class RoleRepository()
{
    public IEnumerable<Role> GetAllRoles() => Database.Connection.GetAll<Role>();

    public Role GetRoleById(int id) => Database.Connection.Get<Role>(id);

    public void CreateRole(Role role) => Database.Connection.Insert(role);
    public void UpdateRole(Role role) => Database.Connection.Update(role);

    public void DeleteRole(int id)
    {
        var role = Database.Connection.Get<Role>(id);
        if (role != null)
            Database.Connection.Delete(role);
    }
}