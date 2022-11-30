using System.Reflection;
using FluentValidation;
using Indimin.Application.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Indimin.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddAutoMapper(assembly);

        return services;
    }

}