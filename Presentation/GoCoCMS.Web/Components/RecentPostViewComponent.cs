using GoCoCMS.Web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace GoCoCMS.Web.Components
{
    public class RecentPostViewComponent : ViewComponent
    {
        private readonly IPostModelFactory _postModelFactory;

        public RecentPostViewComponent(IPostModelFactory postModelFactory)
        {
            _postModelFactory = postModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _postModelFactory.PrepareRecentPostModel();
            return View(model);
        }
    }
}
