using GoCoCMS.Service;
using GoCoCMS.Web.Areas.Admin.Models;
using System;
using System.Linq;

namespace GoCoCMS.Web.Areas.Admin.Factories
{
    public class CategoryModelFactory : ICategoryModelFactory
    {
        #region Fields

        private readonly ICategoryService _categoryService;

        #endregion

        #region Ctor

        public CategoryModelFactory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        #region Methods

        public CategoryListModel PrepareCategoryListModel(CategorySearchModel categorySearchModel)
        {
            if (categorySearchModel == null)
                throw new ArgumentNullException(nameof(categorySearchModel));

            // get categories
            var categories = _categoryService.GetAllCategories(categorySearchModel.SearchCategoryName);

            // prepare view model
            var model = new CategoryListModel()
            {
                Categories = categories.Select(category => new CategoryModel()
                {
                    Id = category.Id,
                    Breadcrumb = _categoryService.GetFormattedBreadCrumb(category),
                    Description = category.Description,
                    DisplayOrder = category.DisplayOrder
                })
            };

            return model;
        }

        #endregion
    }
}
