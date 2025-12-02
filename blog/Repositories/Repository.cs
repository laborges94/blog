using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public abstract class Repository<T>(string connectionString) where T : class
{
    protected readonly string _connectionString = connectionString;

    protected IEnumerable<T> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.GetAll<T>();
    }

    protected T? GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.Get<T>(id);
    }

    protected long Insert(T entity)
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.Insert(entity);
    }

    protected bool Update(T entity)
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.Update(entity);
    }

    protected bool Delete(T entity)
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.Delete(entity);
    }
}