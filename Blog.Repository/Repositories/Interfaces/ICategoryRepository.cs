using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    public interface ICategoryRepository : IBaseRepository<Category> {
        Category this[string categoryName] { get; }
        IEnumerable<Category> LoadCategories(Expression<Func<Category, bool>> filter, int count);
        IEnumerable<Category> LoadCategories<TKey>(Expression<Func<Category, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<Category> LoadCategories<TKey>(Expression<Func<Category, TKey>> orderBy, bool orderByAscending, int skip, int count);
        IEnumerable<Category> LoadCategories<TKey>(Expression<Func<Category, bool>> filter, Expression<Func<Category, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<Category> LoadCategories<TKey>(Expression<Func<Category, bool>> filter, Expression<Func<Category, TKey>> orderBy, bool orderByAscending, int skip, int count);
        IEnumerable<TElement> LoadCollectionByCategory<TElement>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByCategory<TElement, TKey>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByCategory<TElement, TKey>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByCategory<TElement, TKey>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByCategory<TElement, TKey>(Category category, Expression<Func<Category, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class;
    }
}
