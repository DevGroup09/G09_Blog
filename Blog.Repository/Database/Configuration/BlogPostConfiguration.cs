using System.Data.Entity.ModelConfiguration;
using Blog.Domain;

namespace Blog.Repository {
    internal class BlogPostConfiguration : EntityTypeConfiguration<BlogPost> {
        internal BlogPostConfiguration() {
            ToTable("Blogs");

            //Properties
            Property(b => b.IsPublished).IsRequired();
            Property(b => b.IsDeleted).IsRequired();
            Property(b => b.PublishedDate).HasColumnType("date").IsRequired();

            //Not mapped properties
            Ignore(b => b.ViewCount);

            //Relations
            HasOptional(b => b.Draft).WithRequired(d => d.OwnerBlog);
            HasMany(b => b.Comments).WithRequired(c => c.OwnerBlog);
            HasMany(b => b.FavoredBy).WithMany(u => u.FavoriteBlogs)
                                     .Map(m => m.ToTable("BlogsAndUsers")
                                                .MapLeftKey("BlogID")
                                                .MapRightKey("UserID"));

        }
    }
}
