using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain {
    public class UserImage : Image {
        public UserImageType ImageType { get; set; }
        public virtual User OwnerUser { get; set; }
    }

    public enum UserImageType : byte {
        Avatar,
        Media
    }
}
