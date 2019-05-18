using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class UserImageConfiguration : EntityTypeConfiguration<UserImage> {
        internal UserImageConfiguration() {
            ToTable("UserImages");
            Property(ui => ui.ImageType).IsRequired();
        }
    }
}
