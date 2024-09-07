using AutoMapper;
using CleanArchitechture.Application.Abstraction;
using CleanArchitechture.Application.Dtos.User;
using CleanArchitechture.Application.Services.Auth;
using CleanArchitechture.Application.Services.Users;

namespace CleanArchitechture.Application.UseCases.Commands
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public LoginCommandHandler(
            IUserService userService,
            IMapper mapper,
            ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByUserNamePassword(request);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            var userDto = _mapper.Map<GetUserDto>(user);
            var token = _tokenService.GenerateToken(userDto);
            return token;
        }
    }
}
