using System;

namespace Blog.Repository {
    public class BlogUnitOfWork : IUnitOfWork {

        private readonly BlogDbContext _context;
        private UserRepository _users;
        private ArticleRepository _articles;
        private CommentRepository _comments;
        private ImageRepository _images;
        private CategoryRepository _categories;

        public BlogUnitOfWork() {
            _context = new BlogDbContext();
        }

        public IUserRepository Users => _users ?? (_users = new UserRepository(_context));
        public IArticleRepository Articles => _articles ?? (_articles = new ArticleRepository(_context));
        public ICommentRepository Comments => _comments ?? (_comments = new CommentRepository(_context));
        public IImageRepository Images => _images ?? (_images = new ImageRepository(_context));
        public ICategoryRepository Categories => _categories ?? (_categories = new CategoryRepository(_context));

        public void BeginTransaction() {
            if (_context.Database.CurrentTransaction == null)
                _context.Database.BeginTransaction();
        }

        public void Commit() {
            _context.Database.CurrentTransaction?.Commit();
        }

        public void RollBack() {
            _context.Database.CurrentTransaction?.Rollback();
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public void Dispose() {
            _context.Database.CurrentTransaction?.Dispose();
            _context.Dispose();
        }
    }
}
