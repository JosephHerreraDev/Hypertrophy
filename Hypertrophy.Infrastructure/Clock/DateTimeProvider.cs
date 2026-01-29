using Hypertrophy.Application.Abstractions.Clock;

namespace Hypertrophy.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime currentTime => DateTime.UtcNow;
}