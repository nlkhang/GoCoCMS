using Microsoft.AspNetCore.Mvc;

namespace GoCoCMS.Web.Components
{
    public class TopNavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
