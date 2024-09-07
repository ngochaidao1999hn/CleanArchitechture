using CleanArchitechture.Application.Abstraction;
using MediatR;

namespace CleanArchitechture.Application.UseCases.Commands
{
    public sealed record AddUserCommand(string Name, string DateOfBirth, string UserName, string Password) : ICommandBase<Unit>;
}
