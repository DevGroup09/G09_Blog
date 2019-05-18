using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class ContentConfiguration : ComplexTypeConfiguration<Content> {
        internal ContentConfiguration() {
            //properties
            Property(c => c.Title).HasMaxLength(50).IsRequired();
            Property(c => c.Summary).HasMaxLength(200).IsRequired();
            Property(c => c.Text).HasMaxLength(null).IsRequired();
        }
    }
}
