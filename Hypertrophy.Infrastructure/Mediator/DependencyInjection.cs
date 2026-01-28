using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Hypertrophy.Application.Abstractions.Mediator;

namespace Hypertrophy.Infrastructure.Mediator;

public static class DependencyInjection
{
    public static IServiceCollection AddHypertrophyMediator(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        if (assemblies is null || assemblies.Length == 0)
            throw new ArgumentException("At least one assembly is required.", nameof(assemblies));

        // IMediator
        services.AddScoped<IMediator, Mediator>();

        // Scan and register handlers + behaviors
        var allTypes = assemblies.SelectMany(a => a.DefinedTypes)
            .Where(t => !t.IsAbstract && !t.IsInterface);

        foreach (var impl in allTypes)
        {
            foreach (var it in impl.ImplementedInterfaces)
            {
                if (!it.IsGenericType) continue;

                var def = it.GetGenericTypeDefinition();

                if (def == typeof(IRequestHandler<,>))
                    services.AddTransient(it, impl);

                else if (def == typeof(INotificationHandler<>))
                    services.AddTransient(it, impl);

                else if (def == typeof(IPipelineBehavior<,>))
                    services.AddTransient(it, impl);
            }
        }

        return services;
    }
}