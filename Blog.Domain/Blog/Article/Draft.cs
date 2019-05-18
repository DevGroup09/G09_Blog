using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain {
    public class Draft : Article {
        public DateTime CreationDate { get; set; } = DateTime.Today;
        public virtual BlogPost OwnerBlog { get; set; }
    }
}
