using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain {
    public class Comment {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Today;
        public bool IsDeleted { get; set; }

        public virtual User Author { get; set; }
        public virtual BlogPost OwnerBlog { get; set; }
    }
}
