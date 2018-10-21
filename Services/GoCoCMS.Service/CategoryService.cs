using GoCoCMS.Data.Domain;
using GoCoCMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoCoCMS.Service
{
    public class CategoryService : ICategoryService
    {
        #region Fields

        private readonly IRepository<Category> _categoryRepository;

        #endregion

        #region Ctor

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Methods

        public Category GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            return _categoryRepository.GetById(categoryId);
        }

        public IList<Category> GetCategoriesByIds(int[] categoryIds)
        {
            if (categoryIds == null || categoryIds.Length == 0)
                return new List<Category>();

            var query = _categoryRepository.Table.Where(c => categoryIds.Contains(c.Id) && !c.Deleted);

            return query.ToList();
        }

        public virtual IList<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId)
        {
            var query = _categoryRepository.Table;
            query = query.Where(c => c.ParentCategoryId == parentCategoryId);
            query = query.Where(c => !c.Deleted);
            query = query.OrderBy(c => c.DisplayOrder).ThenBy(c => c.Id);

            var categories = query.ToList();
            return categories;
        }

        public void InsertCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _categoryRepository.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            //validate category hierarchy
            var parentCategory = GetCategoryById(category.ParentCategoryId);
            while (parentCategory != null)
            {
                if (category.Id == parentCategory.Id)
                {
                    category.ParentCategoryId = 0;
                    break;
                }

                parentCategory = GetCategoryById(parentCategory.ParentCategoryId);
            }

            _categoryRepository.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            category.Deleted = true;
            UpdateCategory(category);

            //reset a "Parent category" property of all child subcategories
            var subcategories = GetAllCategoriesByParentCategoryId(category.Id);
            foreach (var subcategory in subcategories)
            {
                subcategory.ParentCategoryId = 0;
                UpdateCategory(subcategory);
            }
        }

        public string GetFormattedBreadCrumb(Category category, IList<Category> allCategories = null, string separator = ">>")
        {
            var result = string.Empty;

            // get list of category listed by level
            var breadcrumb = this.GetCategoryBreadCrumb(category, allCategories);
            for (var i = 0; i <= breadcrumb.Count - 1; i++)
            {
                var categoryName = breadcrumb[i].Name;
                result = string.IsNullOrEmpty(result) ? categoryName : $"{result} {separator} {categoryName}";
            }

            return result;
        }

        public IList<Category> GetCategoryBreadCrumb(Category category, IList<Category> allCategories = null)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var result = new List<Category>();

            //used to prevent circular references
            var alreadyProcessedCategoryIds = new List<int>();

            while (!category?.Deleted == true && !alreadyProcessedCategoryIds.Contains(category.Id))
            {
                result.Add(category);

                alreadyProcessedCategoryIds.Add(category.Id);

                category = allCategories != null ? allCategories.FirstOrDefault(c => c.Id == category.ParentCategoryId)
                    : this.GetCategoryById(category.ParentCategoryId);
            }

            result.Reverse();
            return result;
        }

        #endregion
    }
}
