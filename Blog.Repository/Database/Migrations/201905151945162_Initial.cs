namespace Blog.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content_Title = c.String(nullable: false, maxLength: 50),
                        Content_Summary = c.String(nullable: false, maxLength: 200),
                        Content_Text = c.String(nullable: false),
                        Author_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Author_ID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Author_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.Binary(nullable: false, maxLength: 128),
                        Mail = c.String(nullable: false, maxLength: 100, unicode: false),
                        PersonalInfo_FirstName = c.String(nullable: false, maxLength: 70),
                        PersonalInfo_LastName = c.String(nullable: false, maxLength: 100),
                        PersonalInfo_DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        PersonalInfo_Gender = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.UserName, unique: true, name: "Username_Unique")
                .Index(t => t.Mail, unique: true, name: "Mail_Unique");
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 3000),
                        PublishedDate = c.DateTime(nullable: false, storeType: "date"),
                        OwnerBlog_ID = c.Int(nullable: false),
                        Author_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.OwnerBlog_ID)
                .ForeignKey("dbo.Users", t => t.Author_ID, cascadeDelete: true)
                .Index(t => t.OwnerBlog_ID)
                .Index(t => t.Author_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true, name: "Name_Unique");
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(nullable: false, maxLength: 1500, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BlogsAndUsers",
                c => new
                    {
                        BlogID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogID, t.UserID })
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.BlogID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.ArticleImages",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        OwnerArticle_ID = c.Int(nullable: false),
                        ToolTip = c.String(maxLength: 40),
                        ImageType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.ID)
                .ForeignKey("dbo.Articles", t => t.OwnerArticle_ID, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.OwnerArticle_ID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        PublishedDate = c.DateTime(nullable: false, storeType: "date"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Articles", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        OwnerBlog_ID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Articles", t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.OwnerBlog_ID)
                .Index(t => t.ID)
                .Index(t => t.OwnerBlog_ID);
            
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        OwnerUser_ID = c.Int(nullable: false),
                        ImageType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.ID)
                .ForeignKey("dbo.Users", t => t.OwnerUser_ID, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.OwnerUser_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserImages", "OwnerUser_ID", "dbo.Users");
            DropForeignKey("dbo.UserImages", "ID", "dbo.Images");
            DropForeignKey("dbo.Drafts", "OwnerBlog_ID", "dbo.Blogs");
            DropForeignKey("dbo.Drafts", "ID", "dbo.Articles");
            DropForeignKey("dbo.Blogs", "ID", "dbo.Articles");
            DropForeignKey("dbo.ArticleImages", "OwnerArticle_ID", "dbo.Articles");
            DropForeignKey("dbo.ArticleImages", "ID", "dbo.Images");
            DropForeignKey("dbo.Articles", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Articles", "Author_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "Author_ID", "dbo.Users");
            DropForeignKey("dbo.BlogsAndUsers", "UserID", "dbo.Users");
            DropForeignKey("dbo.BlogsAndUsers", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Comments", "OwnerBlog_ID", "dbo.Blogs");
            DropIndex("dbo.UserImages", new[] { "OwnerUser_ID" });
            DropIndex("dbo.UserImages", new[] { "ID" });
            DropIndex("dbo.Drafts", new[] { "OwnerBlog_ID" });
            DropIndex("dbo.Drafts", new[] { "ID" });
            DropIndex("dbo.Blogs", new[] { "ID" });
            DropIndex("dbo.ArticleImages", new[] { "OwnerArticle_ID" });
            DropIndex("dbo.ArticleImages", new[] { "ID" });
            DropIndex("dbo.BlogsAndUsers", new[] { "UserID" });
            DropIndex("dbo.BlogsAndUsers", new[] { "BlogID" });
            DropIndex("dbo.Categories", "Name_Unique");
            DropIndex("dbo.Comments", new[] { "Author_ID" });
            DropIndex("dbo.Comments", new[] { "OwnerBlog_ID" });
            DropIndex("dbo.Users", "Mail_Unique");
            DropIndex("dbo.Users", "Username_Unique");
            DropIndex("dbo.Articles", new[] { "Category_ID" });
            DropIndex("dbo.Articles", new[] { "Author_ID" });
            DropTable("dbo.UserImages");
            DropTable("dbo.Drafts");
            DropTable("dbo.Blogs");
            DropTable("dbo.ArticleImages");
            DropTable("dbo.BlogsAndUsers");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Articles");
        }
    }
}
