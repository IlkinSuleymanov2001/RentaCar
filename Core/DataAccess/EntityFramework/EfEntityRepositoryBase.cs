using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext : DbContext ,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new()) 
            {
                var entityEntry = context.Entry<TEntity>(entity);
                entityEntry.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new())
            {
                var entityEntry = context.Entry<TEntity>(entity);
                entityEntry.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Func<TEntity, bool> filter = null)
        {
            using (TContext context = new())
            {

                return filter == null ? context.Set<TEntity>().ToList():
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Func<TEntity, bool> filter)
        {
            using (TContext context = new())
            {
                return context.Set<TEntity>().Where(filter).FirstOrDefault();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new())
            {
                var entityEntry = context.Entry<TEntity>(entity);
                entityEntry.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
