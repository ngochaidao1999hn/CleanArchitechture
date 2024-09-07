using CleanArchitechture.Application.Abstraction;
using CleanArchitechture.Application.Services.Messages.Kafka;
using CleanArchitechture.Application.Services.Messages.Kafka.Model;
using CleanArchitechture.Application.Services.Users;
using CleanArchitechture.Domain.Entities;
using MediatR;

namespace CleanArchitechture.Application.UseCases.Commands
{
    internal sealed class AddUserCommandHandler : ICommandHandler<AddUserCommand, Unit>
    {
        private readonly IUserService _userService;
        private readonly IProducer _producer;
        public AddUserCommandHandler(IUserService userService, IProducer producer)
        {
            _userService = userService;
            _producer = producer;
        }

        async Task<Unit> IRequestHandler<AddUserCommand, Unit>.Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User().Create(request.Name, request.DateOfBirth, request.UserName, request.Password);
            var newUserId = await _userService.AddNewUserAsync(user);
            await _producer.SendMessage("Test_Replication", new AddUserMessage() { UserId = newUserId, Name = user.Name });
            return Unit.Value;
        }
    }
}
