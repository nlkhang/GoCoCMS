using GoCoCMS.Data.Domain;
using GoCoCMS.Web.Areas.Admin.Models.Post;

namespace GoCoCMS.Web.Areas.Admin.Factories
{
    public interface IBlogPostModelFactory
    {
        BlogPostListModel PrepareBlogPostListModel(BlogPostSearchModel blogPostSearchModel);
        BlogPostModel PrepareBlogPostModel(BlogPostModel blogPostModel, BlogPost blogPost);
    }
}
