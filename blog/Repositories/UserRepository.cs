using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository() : Repository<User>()
{
    public List<User> GetWithRoles()
    {
        var sql = @"
            SELECT u.*, r.*
            FROM [User] u
            LEFT JOIN UserRole ur ON u.Id = ur.UserId
            LEFT JOIN Role r ON ur.RoleId = r.Id";

        var userDict = new Dictionary<int, User>();

        var users = Database.Connection.Query<User, Role, User>(
            sql,
            (user, role) =>
            {
                if (!userDict.TryGetValue(user.Id, out var currentUser))
                {
                    currentUser = user;
                    currentUser.Roles = [];
                    userDict.Add(currentUser.Id, currentUser);
                }

                if (role != null)
                    currentUser.Roles.Add(role);

                return currentUser;
            },
            splitOn: "Id"
        ).Distinct().ToList();

        return users;
    }
}