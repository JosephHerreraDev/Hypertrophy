using Hypertrophy.Domain.Abstractions;

namespace Hypertrophy.Domain.Set;

public class SetErrors
{
    public static Error SetDoesNotExist = new(nameof(SetDoesNotExist));
}
