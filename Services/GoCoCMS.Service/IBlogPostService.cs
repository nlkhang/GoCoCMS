using GoCoCMS.Data.Domain;
using System.Collections.Generic;

namespace GoCoCMS.Service
{
    public interface IBlogPostService
    {
        IList<BlogPost> GetAllBlogPosts(string blogName);
        BlogPost GetBlogPostById(int blogPostId);
        IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds);
        IList<BlogPost> GetAllBlogPostsByBlogCategoryId(int blogCategoryId);
        IList<BlogPost> GetRecentPosts(int numberOfPost);
        void InsertBlogPost(BlogPost blogPost);
        void UpdateBlogPost(BlogPost blogPost);
        void DeleteBlogPost(BlogPost blogPost);
    }
}
