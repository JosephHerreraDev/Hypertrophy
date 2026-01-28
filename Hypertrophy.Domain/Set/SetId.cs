namespace Hypertrophy.Domain.Set;

public record SetId(Guid Value)
{
    public static SetId New() => new(Guid.NewGuid());
}
