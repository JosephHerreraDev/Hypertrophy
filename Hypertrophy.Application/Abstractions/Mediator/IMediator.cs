using Hypertrophy.Domain.Abstractions.Mediator;

namespace Hypertrophy.Application.Abstractions.Mediator;

public interface IMediator
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken ct = default);
    Task Send(IRequest request, CancellationToken ct = default);

    Task Publish<TNotification>(TNotification notification, CancellationToken ct = default)
        where TNotification : INotification;
}

// Unit
public readonly struct Unit
{
    public static readonly Unit Value = new();
}
