using Hypertrophy.Domain.Abstractions;
using MediatR;
namespace Hypertrophy.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
