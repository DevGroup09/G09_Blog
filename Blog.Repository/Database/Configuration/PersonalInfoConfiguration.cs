using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class PersonalInfoConfiguration : ComplexTypeConfiguration<PersonalInfo> {
        internal PersonalInfoConfiguration() {
            Property(p => p.DateOfBirth).HasColumnType("date").IsRequired();
            Property(p => p.FirstName).HasMaxLength(70).IsRequired();
            Property(p => p.LastName).HasMaxLength(100).IsRequired();
            Property(p => p.Gender).IsRequired();
        }
    }
}
