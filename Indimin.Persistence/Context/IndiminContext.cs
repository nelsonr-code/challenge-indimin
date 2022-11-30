using System.Reflection;
using Indimin.Application.Interfaces;
using Indimin.Domain.Entities;
using Indimin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Indimin.Persistence.Context;

public class IndiminContext : DbContext, IIndiminContext
{
    private readonly IDatetimeService _datetimeService;
    public IndiminContext(DbContextOptions<IndiminContext> options, IDatetimeService datetimeService) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _datetimeService = datetimeService;
    }

    public DbSet<Citizen> Citizens { get; set; }
    public DbSet<Tareas> Tareas { get; set; }
    
    public override int SaveChanges()
    {
        // soft delete
        // foreach (var entry in ChangeTracker.Entries()
        //              .Where(entity => entity.State == EntityState.Deleted &&
        //                               entity.Metadata.GetProperties()
        //                                   .Any(prop => prop.Name == "IsDeleted")))
        // {
        //     entry.State = EntityState.Unchanged;
        //     entry.CurrentValues["IsDeleted"] = true;
        // }
        
        foreach (var entry in ChangeTracker.Entries<Tareas>())
        {
            entry.Entity.CreatedAt = entry.State switch
            {
                EntityState.Added => DateTime.Now,
                _ => entry.Entity.CreatedAt
            };
        }
        
        return base.SaveChanges();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}