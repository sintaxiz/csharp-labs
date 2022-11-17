// using System.Linq.Expressions;
// using ChoiceContender.Db.db;
// using ChoiceContender.Db.entities;
// using Microsoft.EntityFrameworkCore;
//
// namespace ChoiceContender.Db.repos;
//
// public class BaseRepo<T> : IDisposable, IRepo<T> where T : BaseEntity, new()
// {
//     private readonly RepoContext _context;
//     
//     private readonly HallContext _db;
//     protected HallContext context => _db;
//
//     public BaseRepo() : this(new HallContext())
//     {
//     }
//
//     public BaseRepo(HallContext context)
//     {
//         _db = context;
//         _table = _db.Set<T>();
//     }
//
//     public void Dispose()
//     {
//         _db.Dispose();
//     }
//
//     public void Add(T entity)
//     { 
//         _db.Add(entity);
//     }
//
//     public void Add(IList<T> entities)
//     {
//         _db.AddRange(entities);
//     }
//
//     public void Update(T entity)
//     {
//         _db.Update(entity);
//     }
//
//     public void Update(IList<T> entities)
//     {
//         _db.UpdateRange(entities);
//     }
//
//
//     public void Delete(T entity)
//     {
//         _db.Entry(entity).State = EntityState.Deleted;
//     }
//     
//     public T GetOne(int? id) => _db.Find(id.Value as object?);
//
//     public List<Attempt?> GetSome(Expression<Func<T, bool>> where)
//     {
//         return _table.Where(where).ToList();
//     }
//
//     public List<Attempt?> GetAll() => _table.ToList();
//
//     public List<Attempt?> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending)
//     {
//         return (ascending ? _table.OrderBy(orderBy) : _table.OrderByDescending(orderBy)).ToList();
//     }
//
//     public List<T> ExecuteQuery(string sql)
//     {
//         return null;
//     }
//
//     public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
//     {
//         throw new NotImplementedException();
//     }
// }