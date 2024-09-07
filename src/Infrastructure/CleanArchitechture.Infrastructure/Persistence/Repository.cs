using CleanArchitechture.Domain;
using CleanArchitechture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitechture.Infrastructure.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private ApplicationDbContext _context;
        private DbSet<TEntity> dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            var ret = await dbSet.AddAsync(entity);
            return ret.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                return false;
            if (dbSet is not ISoftDelete)
            {
                dbSet.Remove(entity);
                return true;
            }
            else
            {
                return true;
            }
        }

        public async Task<IEnumerable<TEntity>?> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
