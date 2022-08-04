using DataAccess.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFrameworkCoreBase
{
    public class EntityRepositoryBase<DBContext, TEntity> : IEntityRepositoryBase<TEntity>
        where TEntity : class, new()
        where DBContext : DbContext
    {
        protected readonly DBContext _dbContext;
        public EntityRepositoryBase(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TEntity Add(TEntity entity)
        {
          return _dbContext.Set<TEntity>().Add(entity).Entity;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(expression);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            if(expression == null)
            {
                return _dbContext.Set<TEntity>().ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(expression).ToList();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Update(entity);
            return entity;
        }
    }
}
