using System.Linq.Expressions;

namespace Indimin.Domain.Interfaces;

public interface IRepositoryBaseline<T> where T : class
{
    void Insert(T entity);
}