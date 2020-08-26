using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
    }
}