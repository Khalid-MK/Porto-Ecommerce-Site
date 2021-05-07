using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Core
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {

        private readonly TContext context;

        private DbSet<TEntity> set;

        public Repository(TContext context)
        {
            this.context = context;
            set = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return set;
        }

        public virtual TEntity GetById(params object[] id)
        {
            return set.Find(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            set.Add(entity);
            return context.SaveChanges() > 0 ? entity : null;
        }

        public virtual List<TEntity> AddList(List<TEntity> entities)
        {
            List<TEntity> result = new List<TEntity>();

            foreach (TEntity entity in entities)
            {
                result.Add(Add(entity));
            }

            return result;
        }

        public  virtual bool Update(TEntity entity)
        {
             set.Update(entity);
            return  context.SaveChanges() > 0;
        }

        public virtual bool Delete(TEntity entity)
        {
            set.Remove(entity);
            return context.SaveChanges() > 0;
        }
    }
}
