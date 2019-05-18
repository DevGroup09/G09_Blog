using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class ArticleConfiguration : EntityTypeConfiguration<Article> {
        internal ArticleConfiguration() {
            //Relations
            HasRequired(a => a.Author).WithMany(u => u.Articles);
            HasRequired(a => a.Category).WithMany(c => c.Articles);
            HasMany(a => a.Images).WithRequired(i => i.OwnerArticle);
        }
    }
}
