using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GoCoCMS.Web.Areas.Admin.Factories
{
    public interface IBaseModelFactory
    {
        void PrepareCategories(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null);
    }
}
