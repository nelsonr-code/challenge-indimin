
using System.Linq.Expressions;

namespace Indimin.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    void Insert(T entity);
    Task<T> FindById(Guid id);
    Task<IEnumerable<T>> FindAll();

    IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
    void Update(T entity);
    void Delete(T entity);
    void Save();

}