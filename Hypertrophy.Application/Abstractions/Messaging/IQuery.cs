using Hypertrophy.Application.Abstractions.Mediator;
using Hypertrophy.Domain.Abstractions;
namespace Hypertrophy.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
