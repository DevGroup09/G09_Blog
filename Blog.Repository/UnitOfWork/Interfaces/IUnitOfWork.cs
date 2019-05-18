using System;

namespace Blog.Repository {
    public interface IUnitOfWork : IDisposable {
        IUserRepository Users { get; }
        IArticleRepository Articles { get; }
        ICommentRepository Comments { get; }
        IImageRepository Images { get; }
        ICategoryRepository Categories { get; }
        void BeginTransaction();
        void Commit();
        void RollBack();
        void SaveChanges();
    }
}
