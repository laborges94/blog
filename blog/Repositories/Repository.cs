using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class Repository<T> where T : class
{    
    public IEnumerable<T> GetAll() => Database.Connection.GetAll<T>();

    public T? GetById(int id) => Database.Connection.Get<T>(id);

    public long Insert(T entity) => Database.Connection.Insert(entity);
    public bool Update(T entity) => Database.Connection.Update(entity);

    public bool Delete(T entity) => Database.Connection.Delete(entity);
}