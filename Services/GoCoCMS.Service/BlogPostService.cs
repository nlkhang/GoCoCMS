using GoCoCMS.Data.Domain;
using GoCoCMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoCoCMS.Service
{
    public class BlogPostService : IBlogPostService
    {
        #region Fields

        private readonly IRepository<BlogPost> _blogPostRepository;

        #endregion

        #region Ctor

        public BlogPostService(IRepository<BlogPost> blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        #endregion

        #region Methods

        public IList<BlogPost> GetAllBlogPosts(string blogName)
        {
            var query = _blogPostRepository.Table;
            if (!string.IsNullOrWhiteSpace(blogName))
                query = query.Where(p => p.Name.Contains(blogName));

            query = query.Where(p => !p.Deleted);
            query = query.OrderByDescending(p => p.CreatedDate);

            return query.ToList();
        }

        public BlogPost GetBlogPostById(int blogPostId)
        {
            if (blogPostId == 0)
                return null;

            return _blogPostRepository.GetById(blogPostId);
        }

        public IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds)
        {
            if (blogPostIds == null || blogPostIds.Length == 0)
                return new List<BlogPost>();

            var query = _blogPostRepository.Table.Where(p => blogPostIds.Contains(p.Id) && !p.Deleted);
            query = query.OrderByDescending(p => p.CreatedDate);

            return query.ToList();
        }

        public IList<BlogPost> GetAllBlogPostsByBlogCategoryId(int blogCategoryId)
        {
            var query = _blogPostRepository.Table.Where(p => p.BlogCategoryId == blogCategoryId);
            query = query.OrderByDescending(p => p.CreatedDate);

            return query.ToList();
        }

        public IList<BlogPost> GetRecentPosts(int numberOfPost)
        {
            var query = _blogPostRepository.Table.Where(p => !p.Deleted);
            query = query.Take(numberOfPost).OrderByDescending(p => p.CreatedDate);

            return query.ToList();
        }

        public void InsertBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException(nameof(blogPost));

            blogPost.CreatedDate = DateTime.Now;
            _blogPostRepository.Insert(blogPost);
        }

        public void UpdateBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException(nameof(blogPost));

            _blogPostRepository.Update(blogPost);
        }

        public void DeleteBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException(nameof(blogPost));

            blogPost.Deleted = true;
            _blogPostRepository.Update(blogPost);
        }

        #endregion
    }
}
