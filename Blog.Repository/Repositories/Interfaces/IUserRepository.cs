using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    public interface IUserRepository : IBaseRepository<User> {
        User this[string username] { get; }
        IEnumerable<User> LoadUsers(Expression<Func<User, bool>> filter, int count);
        IEnumerable<User> LoadUsers<TKey>(Expression<Func<User, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<User> LoadUsers<TKey>(Expression<Func<User, TKey>> orderBy, bool orderByAscending, int skip, int count);
        IEnumerable<User> LoadUsers<TKey>(Expression<Func<User, bool>> filter, Expression<Func<User, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<User> LoadUsers<TKey>(Expression<Func<User, bool>> filter, Expression<Func<User, TKey>> orderBy, bool orderByAscending, int skip, int count);
        IEnumerable<TElement> LoadCollectionByUser<TElement>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByUser<TElement, TKey>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByUser<TElement, TKey>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByUser<TElement, TKey>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByUser<TElement, TKey>(User user, Expression<Func<User, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class;
    }
}
