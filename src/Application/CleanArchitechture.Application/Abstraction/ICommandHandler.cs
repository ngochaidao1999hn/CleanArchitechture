using MediatR;

namespace CleanArchitechture.Application.Abstraction
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommandBase<TResponse>
    {
    }
}
