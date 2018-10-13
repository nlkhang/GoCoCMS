namespace GoCoCMS.Data.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public int? ParentCategoryId { get; set; }
        public bool Deleted { get; set; }
    }
}
