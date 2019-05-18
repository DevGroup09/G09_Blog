using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class ImageConfiguration : EntityTypeConfiguration<Image> {
        internal ImageConfiguration() {
            Property(i => i.ImageURL).HasColumnType("varchar").HasMaxLength(1500).IsRequired();
        }
    }
}
