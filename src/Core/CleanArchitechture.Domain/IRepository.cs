using CleanArchitechture.Domain.Entities;
using System.Linq.Expressions;

namespace CleanArchitechture.Domain
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>?> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity?> GetById(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete (int id);
    }
}
