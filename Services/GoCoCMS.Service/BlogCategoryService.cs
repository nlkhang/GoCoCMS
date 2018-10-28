using GoCoCMS.Data.Domain;
using GoCoCMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoCoCMS.Service
{
    public class BlogCategoryService : IBlogCategoryService
    {
        #region Fields

        private readonly IRepository<BlogCategory> _categoryRepository;

        #endregion

        #region Ctor

        public BlogCategoryService(IRepository<BlogCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Methods

        public IList<BlogCategory> GetAllCategories(string categoryName)
        {
            var query = _categoryRepository.Table;

            if (!string.IsNullOrWhiteSpace(categoryName))
                query = query.Where(c => c.Name.Contains(categoryName));

            query = query.Where(c => !c.Deleted);
            query = query.OrderBy(c => c.ParentCategoryId).ThenBy(c => c.DisplayOrder).ThenBy(c => c.Id);

            var unsortedCategories = query.ToList();

            //sort categories
            var sortedCategories = this.SortCategoriesForTree(unsortedCategories);
            return sortedCategories;

        }

        public BlogCategory GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            return _categoryRepository.GetById(categoryId);
        }

        public IList<BlogCategory> GetCategoriesByIds(int[] categoryIds)
        {
            if (categoryIds == null || categoryIds.Length == 0)
                return new List<BlogCategory>();

            var query = _categoryRepository.Table.Where(c => categoryIds.Contains(c.Id) && !c.Deleted);

            return query.ToList();
        }

        public virtual IList<BlogCategory> GetAllCategoriesByParentCategoryId(int parentCategoryId)
        {
            var query = _categoryRepository.Table.Where(c => c.ParentCategoryId == parentCategoryId && !c.Deleted);
            query = query.OrderBy(c => c.DisplayOrder).ThenBy(c => c.Id);

            return query.ToList();
        }

        public void InsertCategory(BlogCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            _categoryRepository.Insert(category);
        }

        public void UpdateCategory(BlogCategory category)
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

        public void DeleteCategory(BlogCategory category)
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

        public string GetFormattedBreadCrumb(BlogCategory category, IList<BlogCategory> allCategories = null, string separator = ">")
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

        public IList<BlogCategory> GetCategoryBreadCrumb(BlogCategory category, IList<BlogCategory> allCategories = null)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var result = new List<BlogCategory>();

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

        public virtual IList<BlogCategory> SortCategoriesForTree(IList<BlogCategory> source, int parentId = 0,
            bool ignoreCategoriesWithoutExistingParent = false)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var result = new List<BlogCategory>();

            foreach (var cat in source.Where(c => c.ParentCategoryId == parentId).ToList())
            {
                result.Add(cat);
                result.AddRange(SortCategoriesForTree(source, cat.Id, true));
            }

            if (ignoreCategoriesWithoutExistingParent || result.Count == source.Count)
                return result;

            //find categories without parent in provided category source and insert them into result
            foreach (var cat in source)
                if (result.FirstOrDefault(x => x.Id == cat.Id) == null)
                    result.Add(cat);

            return result;
        }

        #endregion
    }
}
