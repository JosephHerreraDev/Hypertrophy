using System;
using Hypertrophy.Infrastructure.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Hypertrophy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHypertrophyMediator(typeof(Hypertrophy.Application.DependencyInjection).Assembly);
        return services;
    }
}