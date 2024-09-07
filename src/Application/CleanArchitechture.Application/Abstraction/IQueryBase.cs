using MediatR;

namespace CleanArchitechture.Application.Abstraction
{
    public interface IQueryBase : IRequest, IRequestBase
    {
    }

    public interface IQueryBase<TResponse> : IRequest<TResponse>, IRequestBase
    {

    }
}
