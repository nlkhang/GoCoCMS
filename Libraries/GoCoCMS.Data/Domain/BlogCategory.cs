using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoCoCMS.Data.Domain
{
    public class BlogCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }
        public int ParentCategoryId { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
