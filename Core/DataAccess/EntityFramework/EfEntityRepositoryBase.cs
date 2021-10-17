using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity item)
        {
            using (TContext context = new TContext())
            {
                var addedBrand = context.Entry(item);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity item)
        {
            using (TContext context = new TContext())
            {
                var deletedBrand = context.Entry(item);
                deletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity item)
        {
            using (TContext context = new TContext())
            {
                var updatedBrand = context.Entry(item);
                updatedBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
