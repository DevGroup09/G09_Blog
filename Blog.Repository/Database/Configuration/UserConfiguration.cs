using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class UserConfiguration : EntityTypeConfiguration<User> {
        internal UserConfiguration() {
            //properties
            Property(u => u.UserName).HasColumnType("varchar")
                                     .HasMaxLength(50)
                                     .IsRequired()
                                     .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                          new IndexAnnotation(new IndexAttribute("Username_Unique") { IsUnique = true }));

            Property(u => u.Mail).HasColumnType("varchar")
                                     .HasMaxLength(100)
                                     .IsRequired()
                                     .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                          new IndexAnnotation(new IndexAttribute("Mail_Unique") { IsUnique = true }));

            Property(u => u.Password).HasMaxLength(128).HasColumnType("varbinary").IsRequired();

            //relations
            HasMany(u => u.UserImages).WithRequired(i => i.OwnerUser);
            HasMany(u => u.Comments).WithRequired(c => c.Author);
        }
    }
}
