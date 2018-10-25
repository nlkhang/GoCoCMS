﻿using GoCoCMS.Data.Domain;
using GoCoCMS.Service;
using GoCoCMS.Web.Areas.Admin.Models;
using GoCoCMS.Web.Infrastructure.Mapper.Extensions;
using System;
using System.Linq;

namespace GoCoCMS.Web.Areas.Admin.Factories
{
    public class CategoryModelFactory : ICategoryModelFactory
    {
        #region Fields

        private readonly ICategoryService _categoryService;
        private readonly IBaseModelFactory _baseModelFactory;

        #endregion

        #region Ctor

        public CategoryModelFactory(ICategoryService categoryService,
            IBaseModelFactory baseModelFactory)
        {
            _categoryService = categoryService;
            _baseModelFactory = baseModelFactory;
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

        public CategoryModel PrepareCategoryModel(CategoryModel categoryModel, Category category)
        {
            if (category != null)
            {
                //fill in model values from the entity
                categoryModel = categoryModel ?? category.ToModel<CategoryModel>();
            }

            // prepare parent categories
            _baseModelFactory.PrepareCategories(categoryModel.AvailableCategories, defaultItemText: "[None]");

            return categoryModel;
        }

        #endregion
    }
}
