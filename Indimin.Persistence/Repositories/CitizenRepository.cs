using System.Linq.Expressions;
using Indimin.Domain.Entities;
using Indimin.Domain.Interfaces;
using Indimin.Persistence.Context;

namespace Indimin.Persistence.Repositories;

public class CitizenRepository : IRepositoryBaseline<Citizen>, ICitizenRepository
{
    private readonly AppDbContext _context;

    public CitizenRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public void Insert(Citizen entity)
    {
        throw new NotImplementedException();
    }
}