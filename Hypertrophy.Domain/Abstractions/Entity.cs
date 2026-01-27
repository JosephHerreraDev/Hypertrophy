namespace Hypertrophy.Domain.Abstractions;

public abstract class Entity<TEntityId> : IEntity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public TEntityId? Id { get; init; }
    protected Entity(TEntityId id)
    {
        Id = id;
    }
    protected Entity()
    {

    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}