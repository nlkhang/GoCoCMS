using GoCoCMS.Data.Domain;
using GoCoCMS.Service;
using GoCoCMS.Web.Areas.Admin.Models.Post;
using GoCoCMS.Web.Infrastructure.Mapper.Extensions;
using System;
using System.Linq;

namespace GoCoCMS.Web.Areas.Admin.Factories
{
    public class BlogPostModelFactory : IBlogPostModelFactory
    {
        #region Fields

        private readonly IBlogPostService _blogPostService;
        private readonly IBaseModelFactory _baseModelFactory;

        #endregion

        #region Ctor

        public BlogPostModelFactory(IBlogPostService blogPostService,
            IBaseModelFactory baseModelFactory)
        {
            _blogPostService = blogPostService;
            _baseModelFactory = baseModelFactory;
        }

        #endregion

        #region Methods

        public BlogPostListModel PrepareBlogPostListModel(BlogPostSearchModel blogPostSearchModel)
        {
            if (blogPostSearchModel == null)
                throw new ArgumentNullException(nameof(blogPostSearchModel));

            // get categories
            var blogPosts = _blogPostService.GetAllBlogPosts(blogPostSearchModel.SearchBlogPostName);

            // prepare view model
            var model = new BlogPostListModel()
            {
                BlogPosts = blogPosts.Select(blogPost => new BlogPostModel()
                {
                    Id = blogPost.Id,
                    Name = blogPost.Name,
                    Content = blogPost.Content,
                    ContentOverview = blogPost.ContentOverview,
                    Category = blogPost.BlogCategory?.Name,
                    CreatedDate = blogPost.CreatedDate,
                    StartDate = blogPost.StartDate,
                    EndDate = blogPost.EndDate                    
                })
            };

            return model;
        }

        public BlogPostModel PrepareBlogPostModel(BlogPostModel blogPostModel, BlogPost blogPost)
        {
            if (blogPost != null)
            {
                //fill in model values from the entity
                blogPostModel = blogPostModel ?? blogPost.ToModel<BlogPostModel>();
            }

            // prepare categories
            _baseModelFactory.PrepareCategories(blogPostModel.AvailableCategories, false);

            return blogPostModel;
        }

        #endregion
    }
}
