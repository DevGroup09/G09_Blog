using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain {
    public class User {
        public User() {
            this.UserImages = new HashSet<UserImage>();
            this.Articles = new HashSet<Article>();
            this.FavoriteBlogs = new HashSet<BlogPost>();
            this.Comments = new HashSet<Comment>();
        }

        public int ID { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public string Mail { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserImage> UserImages { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<BlogPost> FavoriteBlogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
