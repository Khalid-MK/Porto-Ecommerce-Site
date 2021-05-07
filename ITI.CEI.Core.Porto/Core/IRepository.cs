using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.CEI.Core.Porto.Core
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(params object[] id);

        TEntity Add(TEntity entity);

        List<TEntity> AddList(List<TEntity> entities);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);
    }
}
