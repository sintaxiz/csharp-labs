using System.Linq.Expressions;
using ChoiceContender.Db.entities;

namespace ChoiceContender.Db.repos;

public interface IRepo<T>
{
    void Add(T entity);
    void Add(IList<T> entities);
    void Update(T entity);
    void Update(IList<T> entities);
    void Delete(T entity);

    void SaveChanges();
    
    T GetOne(int? id);
     List<T?> GetSome(Expression<Func<T, bool>> where);
     List<T?> GetAll();
    List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending);
    // List<T> ExecuteQuery(string sql);
    // List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
}