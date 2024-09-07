using CleanArchitechture.Domain.Entities;

namespace CleanArchitechture.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<User> _userRepository { get; }
        Task<int> SaveChangeAsync(CancellationToken? cancellationToken);
    }
}
