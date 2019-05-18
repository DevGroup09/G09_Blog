using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain {
    public class BlogPost : Article {
        public BlogPost() {
            this.FavoredBy = new HashSet<User>();
            this.Comments = new HashSet<Comment>();
        }

        public bool IsPublished { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Today;
        public int ViewCount { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Draft Draft { get; set; }
        public virtual ICollection<User> FavoredBy { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
