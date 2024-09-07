using MediatR;

namespace CleanArchitechture.Application.Abstraction
{
    public interface ICommandBase : IRequest, IRequestBase
    {
    }

    public interface ICommandBase<TResponse> : IRequest<TResponse>, IRequestBase
    {

    }
}
