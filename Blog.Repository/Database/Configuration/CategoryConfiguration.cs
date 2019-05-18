using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class CategoryConfiguration : EntityTypeConfiguration<Category> {
        internal CategoryConfiguration() {
            //Properties
            Property(c => c.Name)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                     new IndexAnnotation(new IndexAttribute("Name_Unique") { IsUnique = true }));
        }
    }
}
