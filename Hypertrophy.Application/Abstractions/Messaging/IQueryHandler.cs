using Hypertrophy.Domain.Abstractions;
using MediatR;
namespace Hypertrophy.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
{

}
