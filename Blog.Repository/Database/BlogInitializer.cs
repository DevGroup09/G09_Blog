using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;

namespace Blog.Repository {
    class BlogInitializer : DropCreateDatabaseAlways<BlogDbContext> {
        protected override void Seed(BlogDbContext context) {
            AddUsers(context);
            AddCategories(context);
            AddBlogs(context);
        }

        #region Users

        private void AddUsers(BlogDbContext context) {
            User user1 = GetUser("midas123", new byte[100], "midaste@yahoo.com", GetPersonalInfo("Tengo", "tekturmanidze", new DateTime(1994, 1, 28), Gender.Male));
            User user2 = GetUser("Junior", new byte[100], "junior@gmail.com", GetPersonalInfo("Giorgi", "tekturmanidze", new DateTime(1995, 3, 23), Gender.Male));
            User user3 = GetUser("Ann234", new byte[100], "Ann234@gmail.com", GetPersonalInfo("Ann", "Smith", new DateTime(1988, 7, 28), Gender.Female));
            User user4 = GetUser("Pem4", new byte[100], "Pem4@gmail.com", GetPersonalInfo("Pem", "Fryd", new DateTime(1976, 12, 2), Gender.Female));
            User user5 = GetUser("Linda5", new byte[100], "Linda5@gmail.com", GetPersonalInfo("Linda", "Tompson", new DateTime(1990, 10, 7), Gender.Female), true);
            context.Users.AddRange(new User[] { user1, user2, user3, user4, user5 });
            context.SaveChanges();
        }

        private User GetUser(string username, byte[] password, string mail, PersonalInfo personalInfo, bool isDeleted = false) {
            return new User {
                UserName = username,
                Password = password,
                Mail = mail,
                IsDeleted = isDeleted,
                PersonalInfo = personalInfo
            };
        }

        private PersonalInfo GetPersonalInfo(string firstName, string lastName, DateTime birth, Gender gender) {
            return new PersonalInfo {
                Gender = gender,
                DateOfBirth = birth,
                FirstName = firstName,
                LastName = lastName
            };
        }

        #endregion

        #region Categories
        private void AddCategories(BlogDbContext context) {
            Category category1 = new Category { Name = "Fun" };
            Category category2 = new Category { Name = "Fantasy" };
            Category category3 = new Category { Name = "Politics" };
            Category category4 = new Category { Name = "Movies" };
            context.Categories.AddRange(new Category[] { category1, category2, category3, category4 });
            context.SaveChanges();
        }
        #endregion

        #region Blogs
        private void AddBlogs(BlogDbContext context) {
            BlogPost blogPost1 = new BlogPost {
                Author = context.Users.Find(2),
                Category = context.Categories.Find(1),
                IsPublished = true,
                IsDeleted = false,
            };

            blogPost1.Images.Add(new ArticleImage { ImageType = ArticleImageType.Main, ImageURL = "Wazzap" });
            blogPost1.Images.Add(new ArticleImage { ImageType = ArticleImageType.Content, ImageURL = "Wazzap" });
            blogPost1.Content = GetContent("Title for article 1", "random summary text", "ada asd asd ad ad");

            BlogPost blogPost2 = new BlogPost {
                Author = context.Users.Find(1),
                Category = context.Categories.Find(3),
                IsPublished = true,
                IsDeleted = false,
            };

            blogPost2.Images.Add(new ArticleImage { ImageType = ArticleImageType.Main, ImageURL = "Wazzap" });
            blogPost2.Images.Add(new ArticleImage { ImageType = ArticleImageType.Content, ImageURL = "Wazzap" });
            blogPost2.Content = GetContent("Title for article 2", "random summary text", "ada asd asd ad ad");

            BlogPost blogPost3 = new BlogPost {
                Author = context.Users.Find(1),
                Category = context.Categories.Find(4),
                IsPublished = true,
                IsDeleted = false,
            };

            blogPost3.Images.Add(new ArticleImage { ImageType = ArticleImageType.Main, ImageURL = "Wazzap" });
            blogPost3.Images.Add(new ArticleImage { ImageType = ArticleImageType.Content, ImageURL = "Wazzap" });
            blogPost3.Content = GetContent("Title for article 2", "random summary text", "ada asd asd ad ad");

            BlogPost blogPost4 = new BlogPost {
                Author = context.Users.Find(5),
                Category = context.Categories.Find(4),
                IsPublished = true,
                IsDeleted = false,
            };

            blogPost4.Images.Add(new ArticleImage { ImageType = ArticleImageType.Main, ImageURL = "Wazzap" });
            blogPost4.Images.Add(new ArticleImage { ImageType = ArticleImageType.Content, ImageURL = "Wazzap" });
            blogPost4.Content = GetContent("Title for article 2", "random summary text", "ada asd asd ad ad");

            BlogPost blogPost5 = new BlogPost {
                Author = context.Users.Find(3),
                Category = context.Categories.Find(4),
                IsPublished = true,
                IsDeleted = true,
            };

            blogPost5.Images.Add(new ArticleImage { ImageType = ArticleImageType.Main, ImageURL = "Wazzap" });
            blogPost5.Images.Add(new ArticleImage { ImageType = ArticleImageType.Content, ImageURL = "Wazzap" });
            blogPost5.Content = GetContent("Title for article 2", "random summary text", "ada asd asd ad ad");

            BlogPost blogPost6 = new BlogPost {
                Author = context.Users.Find(1),
                Category = context.Categories.Find(4),
                IsPublished = false,
                IsDeleted = false,
            };

            blogPost6.Images.Add(new ArticleImage { ImageType = ArticleImageType.Main, ImageURL = "Wazzap" });
            blogPost6.Images.Add(new ArticleImage { ImageType = ArticleImageType.Content, ImageURL = "Wazzap" });
            blogPost6.Content = GetContent("Title for article 2", "random summary text", "ada asd asd ad ad");

            BlogPost blogPost7 = new BlogPost {
                Author = context.Users.Find(4),
                Category = context.Categories.Find(2),
                IsPublished = false,
                IsDeleted = true,
            };

            blogPost7.Images.Add(new ArticleImage { ImageType = ArticleImageType.Main, ImageURL = "Wazzap" });
            blogPost7.Images.Add(new ArticleImage { ImageType = ArticleImageType.Content, ImageURL = "Wazzap" });
            blogPost7.Content = GetContent("Title for article 2", "random summary text", "ada asd asd ad ad");

            BlogPost blogPost8 = new BlogPost {
                Author = context.Users.Find(1),
                Category = context.Categories.Find(2),
                IsPublished = true,
                IsDeleted = false,
            };

            blogPost8.Images.Add(new ArticleImage { ImageType = ArticleImageType.Main, ImageURL = "Wazzap" });
            blogPost8.Images.Add(new ArticleImage { ImageType = ArticleImageType.Content, ImageURL = "Wazzap" });
            blogPost8.Content = GetContent("Title for article 2", "random summary text", "ada asd asd ad ad");

            BlogPost blogPost9 = new BlogPost {
                Author = context.Users.Find(3),
                Category = context.Categories.Find(3),
                IsPublished = true,
                IsDeleted = false,
            };

            blogPost9.Images.Add(new ArticleImage { ImageType = ArticleImageType.Main, ImageURL = "Wazzap" });
            blogPost9.Images.Add(new ArticleImage { ImageType = ArticleImageType.Content, ImageURL = "Wazzap" });
            blogPost9.Content = GetContent("Title for article 2", "random summary text", "ada asd asd ad ad");

            context.Articles.AddRange(new BlogPost[] { blogPost1, blogPost2, blogPost3, blogPost4, blogPost5, blogPost6, blogPost7, blogPost8, blogPost9 });
            context.SaveChanges();
        }

        private Content GetContent(string title, string summary, string text) {
            return new Content {
                Title = title,
                Summary = summary,
                Text = text
            };
        }

        #endregion
    }
}
