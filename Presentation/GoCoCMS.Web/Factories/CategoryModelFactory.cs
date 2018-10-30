using GoCoCMS.Data.Domain;
using GoCoCMS.Service;
using GoCoCMS.Web.Infrastructure.Mapper.Extensions;
using GoCoCMS.Web.Models.Category;
using System.Collections.Generic;
using System.Linq;

namespace GoCoCMS.Web.Factories
{
    public class CategoryModelFactory : ICategoryModelFactory
    {
        #region Fields

        private readonly IBlogCategoryService _blogCategoryService;

        #endregion

        #region Ctor

        public CategoryModelFactory(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        #endregion

        #region Methods

        public IList<CategoryModel> PrepareCategoryModel()
        {
            var allCategories = _blogCategoryService.GetAllCategories();
            var model = PrepareSubCategoriesModel(0, allCategories);
            return model;
        }

        public IList<CategoryModel> PrepareSubCategoriesModel(int currentCategoryId, IList<BlogCategory> allCategories)
        {
            var result = new List<CategoryModel>();

            var currentCategories = allCategories.Where(c => c.ParentCategoryId == currentCategoryId);

            foreach (var currentCategory in currentCategories)
            {
                var model = currentCategory.ToModel<CategoryModel>();

                // get child categories
                var subCategories = PrepareSubCategoriesModel(model.Id, allCategories);
                model.SubCategories.AddRange(subCategories);

                result.Add(model);
            }

            return result;
        }

        #endregion
    }
}
