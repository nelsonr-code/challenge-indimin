using System.Collections;
using System.Linq.Expressions;
using Indimin.Application.Interfaces;
using Indimin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Indimin.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly IndiminContext _context;

    public GenericRepository(IndiminContext context)
    {
        _context = context;
    }
    
    private DbSet<T> EntitySet => _context.Set<T>();
    
    public void Insert(T entity)
    {
        EntitySet.Add(entity);
    }

    public async Task<T> FindById(Guid id) => await EntitySet.FindAsync(id);

    public async Task<IEnumerable<T>> FindAll()
    {
        return await EntitySet.ToListAsync();
    }

    public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        EntitySet.Where(expression).AsNoTracking();

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(T entity)
    {
        EntitySet.Remove(entity);
        Save();
    }

    public void Save() => _context.SaveChanges();
    
}