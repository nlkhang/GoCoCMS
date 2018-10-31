using GoCoCMS.Web.Infrastructure.Model;

namespace GoCoCMS.Web.Models.Post
{
    public class PostModel : BaseEntityModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string ThumbnailImage { get; set; }
    }
}
