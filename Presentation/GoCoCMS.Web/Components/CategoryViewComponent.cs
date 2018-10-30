using GoCoCMS.Web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace GoCoCMS.Web.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        #region Fields

        private readonly ICategoryModelFactory _categoryModelFactory;

        #endregion

        #region Ctor

        public CategoryViewComponent(ICategoryModelFactory categoryModelFactory)
        {
            _categoryModelFactory = categoryModelFactory;
        }

        #endregion

        #region Methods

        public IViewComponentResult Invoke()
        {
            var categories = _categoryModelFactory.PrepareCategoryModel();
            return View(categories);
        }

        #endregion
    }
}
