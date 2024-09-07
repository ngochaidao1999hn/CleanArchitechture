using CleanArchitechture.Application.Abstraction;
using CleanArchitechture.Application.Dtos.User;

namespace CleanArchitechture.Application.UseCases.Queries
{
    public record GetListUserQuery(string? Name) : IQueryBase<IEnumerable<ListUserDto>>;

}
