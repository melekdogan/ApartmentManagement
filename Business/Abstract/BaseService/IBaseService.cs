using DataAccess.EntityFrameworkCoreBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.BaseService
{
    public interface IBaseService<TEntity> 
        where TEntity:class,new()
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
    }
}
