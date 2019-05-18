using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    internal class ArticleRepository : BaseRepository<Article>, IArticleRepository {
        internal ArticleRepository(BlogDbContext context) : base(context) {

        }

        public IEnumerable<Article> LoadArticles(Expression<Func<Article, bool>> filter, int count) {
            return LoadEntities(filter: filter, count: count);
        }

        public IEnumerable<Article> LoadArticles<TKey>(Expression<Func<Article, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<Article> LoadArticles<TKey>(Expression<Func<Article, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<Article> LoadArticles<TKey>(Expression<Func<Article, bool>> filter, Expression<Func<Article, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<Article> LoadArticles<TKey>(Expression<Func<Article, bool>> filter, Expression<Func<Article, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByArticle<TElement>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, int count) where TElement : class {
            return LoadCollection(article, collection, filter: filter, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByArticle<TElement, TKey>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class {
            return LoadOrderedCollection(article, collection, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByArticle<TElement, TKey>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class {
            return LoadOrderedCollection(article, collection, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByArticle<TElement, TKey>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int count) where TElement : class {
            return LoadOrderedCollection(article, collection, filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<TElement> LoadCollectionByArticle<TElement, TKey>(Article article, Expression<Func<Article, ICollection<TElement>>> collection, Expression<Func<TElement, bool>> filter, Expression<Func<TElement, TKey>> orderBy, bool orderByAscending, int skip, int count) where TElement : class {
            return LoadOrderedCollection(article, collection, filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }
    }
}
