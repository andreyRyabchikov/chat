using System.Linq.Expressions;
using chat.Entity.Models;

namespace chat.Repository;

public interface IRepository<T> where T : class, IBaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    T GetById(Guid id);
    T Save(T obj);
    void Delete(T obj);
}