using Hypertrophy.Domain.Abstractions.Mediator;

namespace Hypertrophy.Domain.Abstractions;

public abstract class Entity<TEntityId> : IEntity
{
    private readonly List<INotification> _domainEvents = new();

    public TEntityId? Id { get; init; }
    protected Entity(TEntityId id)
    {
        Id = id;
    }
    protected Entity()
    {

    }

    public IReadOnlyList<INotification> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(INotification domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}