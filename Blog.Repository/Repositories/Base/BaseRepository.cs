using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;

namespace Blog.Repository {
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class {

        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        internal BaseRepository(DbContext context) {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity this[object id] => GetById(id);

        public virtual TEntity Add(TEntity entity) {
            return _dbSet.Add(entity);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter) {
            return _dbSet.Where(filter);
        }

        public virtual IEnumerable<TEntity> GetAll() {
            return _dbSet;
        }

        public virtual TEntity GetById(object id) {
            return _dbSet.Find(id);
        }

        public virtual TEntity Remove(object id) {
            return Remove(GetById(id));
        }

        public virtual TEntity Remove(TEntity entity) {
            Attach(entity);
            return _dbSet.Remove(entity);
        }

        public virtual TEntity Attach(TEntity entity) {
            _dbSet.Attach(entity);
            return entity;
        }

        #region Load Entities

        protected virtual IQueryable<TEntity> LoadEntities(Expression<Func<TEntity, bool>> filter = null, int skip = -1, int count = -1) {
            return BuildQuery(_dbSet, filter, skip, count);
        }

        protected virtual IQueryable<TEntity> LoadOrderedEntities<TKey>(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, TKey>> orderBy = null, bool orderByAscending = true, int skip = -1, int count = -1) {
            return BuildOrderedQuery(LoadEntities(filter, skip, count), orderBy, orderByAscending);
        }

        #endregion

        #region Load Entity's Collections
        protected virtual IQueryable<TElement> LoadCollection<TDomain, TElement>(TDomain domain,
                                                                                 Expression<Func<TDomain, ICollection<TElement>>> collection,
                                                                                 Expression<Func<TElement, bool>> filter = null,
                                                                                 int skip = -1,
                                                                                 int count = -1
                                                                                )

                                                          where TDomain : class
                                                          where TElement : class {

            var resultQuery = _context.Entry(domain).Collection(collection).Query();
            resultQuery = BuildQuery(resultQuery, filter, skip, count);
            return resultQuery;
        }

        protected virtual IQueryable<TElement> LoadOrderedCollection<TDomain, TElement, TKey>(TDomain domain,
                                                                                              Expression<Func<TDomain, ICollection<TElement>>> collection,
                                                                                              Expression<Func<TElement, bool>> filter = null,
                                                                                              Expression<Func<TElement, TKey>> orderBy = null,
                                                                                              bool orderByAscending = true,
                                                                                              int skip = -1,
                                                                                              int count = -1
                                                                                              )

                                                          where TDomain : class
                                                          where TElement : class {

            var resultQuery = this.LoadCollection(domain, collection, filter, skip, count);
            resultQuery = BuildOrderedQuery(resultQuery, orderBy, orderByAscending);
            return resultQuery;
        }

        #endregion

        #region Query Builders

        private static IQueryable<TElement> BuildQuery<TElement>(IQueryable<TElement> resultQuery, Expression<Func<TElement, bool>> filter = null, int skip = -1, int count = -1) where TElement : class {
            if (filter != null)
                resultQuery = resultQuery.Where(filter);
            if (skip > -1)
                resultQuery = resultQuery.Skip(skip);
            if (count > -1)
                resultQuery = resultQuery.Take(count);
            return resultQuery;
        }

        private static IQueryable<TElement> BuildOrderedQuery<TElement, TKey>(IQueryable<TElement> resultQuery, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending) where TElement : class {
            if (orderBy != null)
                resultQuery = orderByAscending ? resultQuery.OrderBy(orderBy) : resultQuery.OrderByDescending(orderBy);
            return resultQuery;
        }

        #endregion
    }
}
