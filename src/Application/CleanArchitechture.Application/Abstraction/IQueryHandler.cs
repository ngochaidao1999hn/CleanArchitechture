using MediatR;


namespace CleanArchitechture.Application.Abstraction
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
      where TQuery : IQueryBase<TResponse>
    {
    }
}
