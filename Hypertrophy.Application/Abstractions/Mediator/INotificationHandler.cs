using Hypertrophy.Domain.Abstractions.Mediator;

namespace Hypertrophy.Application.Abstractions.Mediator;

public interface INotificationHandler<in TNotification>
    where TNotification : INotification
{
    Task Handle(TNotification notification, CancellationToken ct);
}
