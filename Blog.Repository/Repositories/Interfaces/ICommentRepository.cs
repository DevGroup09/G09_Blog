using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    public interface ICommentRepository : IBaseRepository<Comment> {
        IEnumerable<Comment> LoadComments(Expression<Func<Comment, bool>> filter, int count);
        IEnumerable<Comment> LoadComments<TKey>(Expression<Func<Comment, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<Comment> LoadComments<TKey>(Expression<Func<Comment, TKey>> orderBy, bool orderByAscending, int skip, int count);
        IEnumerable<Comment> LoadComments<TKey>(Expression<Func<Comment, bool>> filter, Expression<Func<Comment, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<Comment> LoadComments<TKey>(Expression<Func<Comment, bool>> filter, Expression<Func<Comment, TKey>> orderBy, bool orderByAscending, int skip, int count);
    }
}
