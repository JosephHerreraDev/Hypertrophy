namespace Hypertrophy.Domain.Abstractions;

public record Error(string MessageKey)
{
    public static Error None = new(string.Empty);
    public static Error NullValue = new("Null value Error");
}