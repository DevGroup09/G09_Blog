using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    internal class CommentRepository : BaseRepository<Comment>, ICommentRepository {
        internal CommentRepository(BlogDbContext context) : base(context) {

        }

        public IEnumerable<Comment> LoadComments(Expression<Func<Comment, bool>> filter, int count) {
            return LoadEntities(filter: filter, count: count);
        }

        public IEnumerable<Comment> LoadComments<TKey>(Expression<Func<Comment, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<Comment> LoadComments<TKey>(Expression<Func<Comment, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }

        public IEnumerable<Comment> LoadComments<TKey>(Expression<Func<Comment, bool>> filter, Expression<Func<Comment, TKey>> orderBy, bool orderByAscending, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, count: count);
        }

        public IEnumerable<Comment> LoadComments<TKey>(Expression<Func<Comment, bool>> filter, Expression<Func<Comment, TKey>> orderBy, bool orderByAscending, int skip, int count) {
            return LoadOrderedEntities(filter: filter, orderBy: orderBy, orderByAscending: orderByAscending, skip: skip, count: count);
        }
    }
}
