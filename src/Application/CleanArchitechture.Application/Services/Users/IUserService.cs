using CleanArchitechture.Application.Dtos.User;
using CleanArchitechture.Application.UseCases.Commands;
using CleanArchitechture.Domain.Entities;

namespace CleanArchitechture.Application.Services.Users
{
    public interface IUserService
    {
        Task<int> AddNewUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<User?> GetUserByUserNamePassword(LoginCommand request);
    }
}
