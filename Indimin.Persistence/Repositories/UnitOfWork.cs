using Indimin.Domain.Interfaces;
using Indimin.Persistence.Context;

namespace Indimin.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public ICitizenRepository Citizens { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Citizens = new CitizenRepository(_context);
    }
    
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

}