using FluentValidation;

namespace CleanArchitechture.Application.UseCases.Commands
{
    public sealed class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty()
                .MaximumLength(10);
        }
    }
}
