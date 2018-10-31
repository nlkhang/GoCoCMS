using GoCoCMS.Web.Models.Post;
using System.Collections.Generic;

namespace GoCoCMS.Web.Factories
{
    public interface IPostModelFactory
    {
        IList<PostModel> PrepareRecentPostModel();
        IList<PostModel> PrepareHomePagePostModel();
    }
}
