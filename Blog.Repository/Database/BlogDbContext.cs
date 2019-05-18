using System.Data.Entity;
using Blog.Domain;

namespace Blog.Repository {
    public class BlogDbContext : DbContext {

        // for testing
        static BlogDbContext() {
            System.Data.Entity.Database.SetInitializer<BlogDbContext>(new BlogInitializer()/* null*/);
        }

        public BlogDbContext() : base("name=BlogCS") {

        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new ArticleImageConfiguration());
            modelBuilder.Configurations.Add(new BlogPostConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new ContentConfiguration());
            modelBuilder.Configurations.Add(new DraftConfiguration());
            modelBuilder.Configurations.Add(new ImageConfiguration());
            modelBuilder.Configurations.Add(new PersonalInfoConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserImageConfiguration());
        }
    }
}
