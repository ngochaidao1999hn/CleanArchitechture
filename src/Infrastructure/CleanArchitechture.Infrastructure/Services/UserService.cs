using CleanArchitechture.Application.Dtos.User;
using CleanArchitechture.Application.Services.Users;
using CleanArchitechture.Application.UseCases.Commands;
using CleanArchitechture.Domain;
using CleanArchitechture.Domain.Entities;

namespace CleanArchitechture.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;          
        }
        public async Task<int> AddNewUserAsync(User user)
        {
            var ret = await _unitOfWork._userRepository.Add(user);
            await _unitOfWork.SaveChangeAsync(default);
            return ret.Id;
        }

        public async Task<User?> GetUserByUserNamePassword(LoginCommand request)
        {
            var user = (await _unitOfWork._userRepository.GetAll(x => x.UserName == request.UserName && x.Password == request.Password))?.FirstOrDefault();
            return user;
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
