using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class CommentConfiguration : EntityTypeConfiguration<Comment> {
        internal CommentConfiguration() {
            //properties
            Property(c => c.Text).HasMaxLength(3000).IsRequired();
            Property(c => c.PublishedDate).HasColumnType("date").IsRequired();
        }
    }
}
