using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Repository {
    public interface IBaseRepository<TEntity> where TEntity : class {
        TEntity Add(TEntity entity);
        TEntity Attach(TEntity entity);
        TEntity Remove(object id);
        TEntity Remove(TEntity entity);
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
    }
}
