using Hypertrophy.Domain.Abstractions.Mediator;

namespace Hypertrophy.Domain.Abstractions;

public interface IEntity
{
    IReadOnlyList<INotification> GetDomainEvents();

    void ClearDomainEvents();
}