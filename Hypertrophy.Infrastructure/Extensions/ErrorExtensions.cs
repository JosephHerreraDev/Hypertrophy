using System.Reflection;
using System.Resources;
using Hypertrophy.Domain.Abstractions;

namespace Hypertrophy.Infrastructure.Extensions;

public static class ErrorExtensions
{
    private static readonly List<ResourceManager> _resourceManagers;

    static ErrorExtensions()
    {
        var infrastructureAssembly = typeof(ErrorExtensions).Assembly;

        _resourceManagers = infrastructureAssembly.GetTypes()
            .Where(t => t.IsClass && t.Namespace == "Support.Infrastructure.Resources")
            .Select(t => t.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            .Where(p => p != null)
            .Select(p => (ResourceManager)p?.GetValue(null)!)
            .ToList();
    }

    public static string ToLocalizedMessage(this Error error)
    {
        foreach (var rm in _resourceManagers)
        {
            var message = rm.GetString(error.MessageKey, Thread.CurrentThread.CurrentUICulture);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return message;
            }
        }

        return error.MessageKey;
    }
}