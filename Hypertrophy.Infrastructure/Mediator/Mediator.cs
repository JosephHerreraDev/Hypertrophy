using System.Collections;
using Hypertrophy.Application.Abstractions.Mediator;
using Hypertrophy.Domain.Abstractions.Mediator;

namespace Hypertrophy.Infrastructure.Mediator;

public sealed class Mediator : IMediator
{
    private readonly IServiceProvider _sp;

    public Mediator(IServiceProvider sp)
    {
        _sp = sp ?? throw new ArgumentNullException(nameof(sp));
    }

    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken ct = default)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        var requestType = request.GetType();
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));
        var handler = _sp.GetService(handlerType)
            ?? throw new InvalidOperationException(
                $"No handler registered for request '{requestType.FullName}' with response '{typeof(TResponse).FullName}'.");

        RequestHandlerDelegate<TResponse> invokeHandler = (token) => ((dynamic)handler).Handle((dynamic)request, token);

        var behaviors = ResolveBehaviors(requestType, typeof(TResponse));

        for (var i = behaviors.Count - 1; i >= 0; i--)
        {
            var behavior = behaviors[i];
            var next = invokeHandler;

            invokeHandler = (token) =>
                ((dynamic)behavior).Handle((dynamic)request, token, next);
        }

        return invokeHandler(ct);
    }

    public Task Send(IRequest request, CancellationToken ct = default)
        => Send<Unit>(request, ct);

    public Task Publish<TNotification>(TNotification notification, CancellationToken ct = default)
        where TNotification : INotification
    {
        if (notification is null) throw new ArgumentNullException(nameof(notification));

        var notificationType = notification.GetType();
        var handlerType = typeof(INotificationHandler<>).MakeGenericType(notificationType);
        var enumerableType = typeof(IEnumerable<>).MakeGenericType(handlerType);

        var handlersObj = _sp.GetService(enumerableType);
        var handlers = (handlersObj as IEnumerable)?.Cast<object>().ToArray() ?? Array.Empty<object>();

        return PublishSequential(notification, ct, handlers);
    }

    private static async Task PublishSequential<TNotification>(
        TNotification notification,
        CancellationToken ct,
        object[] handlers)
        where TNotification : INotification
    {
        foreach (var h in handlers)
            await ((dynamic)h).Handle((dynamic)notification, ct).ConfigureAwait(false);
    }

    private List<object> ResolveBehaviors(Type requestType, Type responseType)
    {
        var behaviorType = typeof(IPipelineBehavior<,>).MakeGenericType(requestType, responseType);
        var enumerableType = typeof(IEnumerable<>).MakeGenericType(behaviorType);

        var behaviorsObj = _sp.GetService(enumerableType);
        return (behaviorsObj as IEnumerable)?.Cast<object>().ToList() ?? new List<object>();
    }
}