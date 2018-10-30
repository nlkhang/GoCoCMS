using GoCoCMS.Data.Domain;
using GoCoCMS.Service;
using GoCoCMS.Web.Infrastructure.Mapper.Extensions;
using GoCoCMS.Web.Models.Post;
using System.Collections.Generic;

namespace GoCoCMS.Web.Factories
{
    public class PostModelFactory : IPostModelFactory
    {
        #region Fields

        private readonly IBlogPostService _blogPostService;

        #endregion

        #region Ctor

        public PostModelFactory(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        #endregion

        #region Methods

        public IList<PostModel> PrepareRecentPostModel()
        {
            var posts =  _blogPostService.GetRecentPosts(10);
            var postModel = posts.ToModel< IList<PostModel>, BlogPost>();

            return postModel;
        }

        #endregion
    }
}
