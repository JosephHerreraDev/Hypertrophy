using System;
using Hypertrophy.Application.Abstractions.Clock;
using Hypertrophy.Domain.Abstractions;
using Hypertrophy.Domain.Exercise;
using Hypertrophy.Infrastructure.Clock;
using Hypertrophy.Infrastructure.Identity;
using Hypertrophy.Infrastructure.Mediator;
using Hypertrophy.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hypertrophy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration
    )
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        var connectionString = configuration.GetConnectionString("ConnectionString")
             ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

        services.AddScoped<IExerciseRepository, ExerciseRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddHypertrophyMediator(typeof(Hypertrophy.Application.DependencyInjection).Assembly);

        return services;
    }
}