using System.Collections.Generic;

namespace GoCoCMS.Web.Areas.Admin.Models.Post
{
    public class BlogPostListModel
    {
        public BlogPostListModel()
        {
            BlogPosts = new List<BlogPostModel>();
            BlogPostSearchModel = new BlogPostSearchModel();
        }

        public BlogPostSearchModel BlogPostSearchModel { get; set; }
        public IEnumerable<BlogPostModel> BlogPosts { get; set; }
    }
}
