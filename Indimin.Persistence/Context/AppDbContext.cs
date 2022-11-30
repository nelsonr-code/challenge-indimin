using System.Reflection;
using Indimin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Indimin.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    
    // public DbSet<Citizen> Citizens { get; set; }
    // public DbSet<Task> Tasks { get; set; }

    /*
    public override int SaveChanges()
    {
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
    */
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}