using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class DraftConfiguration : EntityTypeConfiguration<Draft> {
        internal DraftConfiguration() {
            ToTable("Drafts");

            //properties
            Property(d => d.CreationDate).HasColumnType("date").IsRequired();
        }
    }
}
