using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    public interface IArticleRepository : IBaseRepository<Article> {
        IEnumerable<Article> LoadArticles(Expression<Func<Article, bool>> filter, int count);
        IEnumerable<Article> LoadArticles<TKey>(Expression<Func<Article, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<Article> LoadArticles<TKey>(Expression<Func<Article, TKey>> orderBy, bool orderByAscending, int skip, int count);
        IEnumerable<Article> LoadArticles<TKey>(Expression<Func<Article, bool>> filter, Expression<Func<Article, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<Article> LoadArticles<TKey>(Expression<Func<Article, bool>> filter, Expression<Func<Article, TKey>> orderBy, bool orderByAscending, int skip, int count);
        IEnumerable<TElement> LoadCollectionByArticle<TElement>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByArticle<TElement, TKey>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByArticle<TElement, TKey>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByArticle<TElement, TKey>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class;
        IEnumerable<TElement> LoadCollectionByArticle<TElement, TKey>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class;
    }
}
