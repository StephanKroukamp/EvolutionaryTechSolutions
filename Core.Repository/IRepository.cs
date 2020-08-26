using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<TEntity> Add(TEntity entity);

        IQueryable<TEntity> Query(bool eager = false);

        Task<List<TEntity>> Get(bool eager = false);

        Task<TEntity> Get(int id, bool eager = false);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Delete(int id);
    }
}