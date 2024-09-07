using CleanArchitechture.Domain;
using CleanArchitechture.Domain.Entities;
using CleanArchitechture.Infrastructure.Persistence;

namespace CleanArchitechture.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;

        public IRepository<User> _userRepository { get;}
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _userRepository = new Repository<User>(_context);
        }

        public async Task<int> SaveChangeAsync(CancellationToken? cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken ?? default);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
