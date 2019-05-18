using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class ArticleImageConfiguration : EntityTypeConfiguration<ArticleImage> {
        internal ArticleImageConfiguration() {
            ToTable("ArticleImages");

            //properties
            Property(a => a.ToolTip).HasMaxLength(40).IsOptional();
            Property(a => a.ImageType).IsRequired();
        }
    }
}
