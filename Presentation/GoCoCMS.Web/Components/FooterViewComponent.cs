using Microsoft.AspNetCore.Mvc;

namespace GoCoCMS.Web.Components
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
