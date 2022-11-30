using Indimin.Application.Interfaces;
using Indimin.Domain.Interfaces;
using Indimin.Persistence.Context;
using Indimin.Persistence.Repositories;
using Indimin.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Indimin.Persistence;

public static class PersistenceExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(IndiminContext).Assembly.FullName;

        services.AddDbContext<IndiminContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("ExperticeIT"),
                b => b.MigrationsAssembly(assembly))
        );

        // var assembly = typeof(AppDbContext).Assembly.FullName;
        //
        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseSqlServer(
        //         configuration.GetConnectionString("ExperticeIT"),
        //         b => b.MigrationsAssembly(assembly))
        // );

        #region Repositories

        // services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        #endregion

        #region Services

        services.AddTransient(typeof(IDatetimeService), typeof(DateTimeService));

        #endregion

        return services;
    }
}