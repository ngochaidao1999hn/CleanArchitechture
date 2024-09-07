using CleanArchitechture.Application.Abstraction;

namespace CleanArchitechture.Application.UseCases.Commands
{
    public record LoginCommand(string UserName, string Password) : ICommandBase<string>; 
}
