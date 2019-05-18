using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain {
    public class ArticleImage : Image {
        public string ToolTip { get; set; }
        public ArticleImageType ImageType { get; set; }

        public virtual Article OwnerArticle { get; set; }
    }

    public enum ArticleImageType : byte {
        Main,
        Content,
        Slide
    }
}
