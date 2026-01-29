using System;

namespace Hypertrophy.Application.Abstractions.Mediator;

public interface ISender
{
    Task<TResponse> Send<TResponse>(
        IRequest<TResponse> request,
        CancellationToken ct = default);
}