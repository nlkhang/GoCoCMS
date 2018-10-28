using System.ComponentModel.DataAnnotations;

namespace GoCoCMS.Web.Areas.Admin.Models.Post
{
    public class BlogPostSearchModel
    {
        [Display(Name = "Blog Post Name")]
        public string SearchBlogPostName { get; set; }
    }
}
