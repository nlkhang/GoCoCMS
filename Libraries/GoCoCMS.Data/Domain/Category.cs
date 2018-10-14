using System.ComponentModel.DataAnnotations;

namespace GoCoCMS.Data.Domain
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }
        public bool Deleted { get; set; }
    }
}
