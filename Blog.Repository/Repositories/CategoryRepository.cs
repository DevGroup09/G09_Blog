using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository {
        internal CategoryRepository(BlogDbContext context) : base(context) {

        }

        public Category this[string categoryName] => _dbSet.SingleOrDefault(c => c.Name == categoryName);

        public IEnumerable<Category> LoadCategories(Expression<Func<Category, bool>> filter, int count) {
            return LoadEntities(filter: filter, count: count);
        }

        public IEnumerable<Category> LoadCategories<TKey>(Expression<Func<Category, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<Category> LoadCategories<TKey>(Expression<Func<Category, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<Category> LoadCategories<TKey>(Expression<Func<Category, bool>> filter, Expression<Func<Category, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<Category> LoadCategories<TKey>(Expression<Func<Category, bool>> filter, Expression<Func<Category, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByCategory<TElement>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, int count) where TElement : class {
            return LoadCollection(category, collection, filter: filter, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByCategory<TElement, TKey>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class {
            return LoadOrderedCollection(category, collection, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByCategory<TElement, TKey>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class {
            return LoadOrderedCollection(category, collection, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByCategory<TElement, TKey>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class {
            return LoadOrderedCollection(category, collection, filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByCategory<TElement, TKey>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class {
            return LoadOrderedCollection(category, collection, filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }
    }
}
