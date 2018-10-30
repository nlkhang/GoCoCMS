using Microsoft.AspNetCore.Mvc;

namespace GoCoCMS.Web.Components
{
    public class SearchViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
