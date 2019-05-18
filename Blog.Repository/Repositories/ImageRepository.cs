using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    internal class ImageRepository : BaseRepository<Image>, IImageRepository {
        internal ImageRepository(BlogDbContext context) : base(context) {

        }

        public IEnumerable<Image> LoadImages(Expression<Func<Image, bool>> filter, int count) {
            return LoadEntities(filter: filter, count: count);
        }

        public IEnumerable<Image> LoadImages<TKey>(Expression<Func<Image, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<Image> LoadImages<TKey>(Expression<Func<Image, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<Image> LoadImages<TKey>(Expression<Func<Image, bool>> filter, Expression<Func<Image, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<Image> LoadImages<TKey>(Expression<Func<Image, bool>> filter, Expression<Func<Image, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }
    }
}
