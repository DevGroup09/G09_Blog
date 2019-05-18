using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    internal class UserRepository : BaseRepository<User>, IUserRepository {
        internal UserRepository(BlogDbContext context) : base(context) {

        }

        public User this[string username] => _dbSet.SingleOrDefault(u => u.UserName == username);

        public IEnumerable<TElement> LoadCollectionByUser<TElement>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, int count) where TElement : class {
            return LoadCollection(user, collection, filter: filter, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByUser<TElement, TKey>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class {
            return LoadOrderedCollection(user, collection, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByUser<TElement, TKey>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class {
            return LoadOrderedCollection(user, collection, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByUser<TElement, TKey>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class {
            return LoadOrderedCollection(user, collection, filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByUser<TElement, TKey>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class {
            return LoadOrderedCollection(user, collection, filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<User> LoadUsers(Expression<Func<User, bool>> filter, int count) {
            return LoadEntities(filter: filter, count: count);
        }

        public IEnumerable<User> LoadUsers<TKey>(Expression<Func<User, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<User> LoadUsers<TKey>(Expression<Func<User, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<User> LoadUsers<TKey>(Expression<Func<User, bool>> filter, Expression<Func<User, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<User> LoadUsers<TKey>(Expression<Func<User, bool>> filter, Expression<Func<User, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }
    }
}
