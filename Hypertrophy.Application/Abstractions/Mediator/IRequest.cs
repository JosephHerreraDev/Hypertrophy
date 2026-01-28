namespace Hypertrophy.Application.Abstractions.Mediator;

public interface IRequest<out TResponse> { }
public interface IRequest : IRequest<Unit> { }
