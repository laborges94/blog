using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public abstract class Repository<T>(SqlConnection connection) where T : class
{
    protected readonly SqlConnection _connection = connection;

    protected IEnumerable<T> GetAll() => _connection.GetAll<T>();

    protected T? GetById(int id) => _connection.Get<T>(id);

    protected long Insert(T entity) => _connection.Insert(entity);

    protected bool Update(T entity) => _connection.Update(entity);

    protected bool Delete(T entity) => _connection.Delete(entity);
}