using Hypertrophy.Application.Abstractions.Mediator;
using Hypertrophy.Domain.Abstractions;
namespace Hypertrophy.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
{

}
