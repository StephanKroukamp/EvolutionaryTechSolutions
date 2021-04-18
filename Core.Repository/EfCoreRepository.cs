using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext context;

        public EfCoreRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public IQueryable<TEntity> Query(bool eager = false)
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (eager)
            {
                foreach (var property in context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                {
                    query = query.Include(property.Name);
                } 
            }

            return query;
        }

        public async Task<List<TEntity>> Get(bool eager = false)
        {
            List<TEntity> entities = await Query(eager).ToListAsync();
            
            return entities;
        }

        public async Task<TEntity> Get(int id, bool eager = false)
        {
            return await Query(eager).SingleOrDefaultAsync(i => i.Id == id);
        }
        
        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);

            await context.SaveChangesAsync();

            return entity;
        }
    }
}