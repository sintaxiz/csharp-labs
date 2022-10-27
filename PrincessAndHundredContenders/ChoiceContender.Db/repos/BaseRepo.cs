using System.Linq.Expressions;
using ChoiceContender.Db.db;
using ChoiceContender.Db.entities;
using Microsoft.EntityFrameworkCore;

namespace ChoiceContender.Db.repos;

public class BaseRepo<T> : IDisposable, IRepo<T> where T : BaseEntity, new()
{
    private readonly DbSet<T> _table;
    private readonly HallContext _db;
    protected HallContext context => _db;

    public BaseRepo() : this(new HallContext())
    {
    }

    public BaseRepo(HallContext context)
    {
        _db = context;
        _table = _db.Set<T>();
    }

    public void Dispose()
    {
        _db.Dispose();
    }

    public int Add(T entity)
    {
        _table.Add(entity);
        return _db.SaveChanges();
        ;
    }

    public int Add(IList<T> entities)
    {
        _table.AddRange(entities);
        return _db.SaveChanges();
    }

    public int Update(T entity)
    {
        _table.Update(entity);
        return 0;
    }

    public int Update(IList<T> entities)
    {
        _table.UpdateRange(entities);
        return 0;
    }


    public int Delete(T entity)
    {
        _db.Entry(entity).State = EntityState.Deleted;
        return 0;
    }

    public T GetOne(int? id) => _table.Find(id);

    public List<T> GetSome(Expression<Func<T, bool>> where)
    {
        return _table.Where(where).ToList();
    }

    public List<T> GetAll() => _table.ToList();

    public List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending)
    {
        return (ascending ? _table.OrderBy(orderBy) : _table.OrderByDescending(orderBy)).ToList();
    }

    public List<T> ExecuteQuery(string sql)
    {
        return null;
    }

    public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
    {
        throw new NotImplementedException();
    }
}