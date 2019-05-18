using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain {
    public abstract class Article {
        public Article() {
            this.Images = new HashSet<ArticleImage>();
        }

        public int ID { get; set; }
        public Content Content { get; set; }

        public virtual User Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ArticleImage> Images { get; set; }
    }
}
