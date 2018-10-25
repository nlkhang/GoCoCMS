using GoCoCMS.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoCoCMS.Web.Areas.Admin.Factories
{
    public class BaseModelFactory : IBaseModelFactory
    {
        #region Fields

        private readonly ICategoryService _categoryService;

        #endregion

        #region Ctor

        public BaseModelFactory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        #region Methods

        public virtual void PrepareCategories(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            //prepare available categories
            var categories = _categoryService.GetAllCategories(string.Empty);
            var availableCategoryItems = categories.Select(c => new SelectListItem
            {
                Text = _categoryService.GetFormattedBreadCrumb(c, categories),
                Value = c.Id.ToString()
            });
            foreach (var categoryItem in availableCategoryItems)
            {
                items.Add(categoryItem);
            }

            //insert special item for the default value
            PrepareDefaultItem(items, withSpecialDefaultItem, defaultItemText);
        }

        #endregion

        #region Utilities

        protected virtual void PrepareDefaultItem(IList<SelectListItem> items, bool withSpecialDefaultItem, string defaultItemText = null)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            //whether to insert the first special item for the default value
            if (!withSpecialDefaultItem)
                return;

            //at now we use "0" as the default value
            const string value = "0";

            //prepare item text
            defaultItemText = defaultItemText ?? "All";

            //insert this default item at first
            items.Insert(0, new SelectListItem { Text = defaultItemText, Value = value });
        }

        #endregion
    }
}
