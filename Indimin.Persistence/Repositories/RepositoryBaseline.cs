using System.Linq.Expressions;
using Indimin.Domain.Interfaces;

namespace Indimin.Persistence.Repositories;

public class RepositoryBaseline<T> : IRepositoryBaseline<T> where T : class
{
    public void Insert(T entity)
    {
        throw new NotImplementedException();
    }

}