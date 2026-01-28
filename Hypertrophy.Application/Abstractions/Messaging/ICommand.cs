using Hypertrophy.Application.Abstractions.Mediator;
using Hypertrophy.Domain.Abstractions;
namespace Hypertrophy.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{

}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{

}

public interface IBaseCommand
{

}
