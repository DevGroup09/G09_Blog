using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Domain;

namespace Blog.Repository {
    public interface IImageRepository : IBaseRepository<Image> {
        IEnumerable<Image> LoadImages(Expression<Func<Image, bool>> filter, int count);
        IEnumerable<Image> LoadImages<TKey>(Expression<Func<Image, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<Image> LoadImages<TKey>(Expression<Func<Image, TKey>> orderBy, bool orderByAscending, int skip, int count);
        IEnumerable<Image> LoadImages<TKey>(Expression<Func<Image, bool>> filter, Expression<Func<Image, TKey>> orderBy, bool orderByAscending, int count);
        IEnumerable<Image> LoadImages<TKey>(Expression<Func<Image, bool>> filter, Expression<Func<Image, TKey>> orderBy, bool orderByAscending, int skip, int count);
    }
}
