using GoCoCMS.Data.Domain;
using System.Collections.Generic;

namespace GoCoCMS.Service
{
    public interface IBlogCategoryService
    {
        IList<BlogCategory> GetAllCategories(string categoryName = "");
        BlogCategory GetCategoryById(int categoryId);
        IList<BlogCategory> GetCategoriesByIds(int[] categoryIds);
        IList<BlogCategory> GetAllCategoriesByParentCategoryId(int parentCategoryId);
        void InsertCategory(BlogCategory category);
        void UpdateCategory(BlogCategory category);
        void DeleteCategory(BlogCategory category);
        string GetFormattedBreadCrumb(BlogCategory category, IList<BlogCategory> allCategories = null, string separator = ">");
        IList<BlogCategory> GetCategoryBreadCrumb(BlogCategory category, IList<BlogCategory> allCategories = null);
        IList<BlogCategory> SortCategoriesForTree(IList<BlogCategory> source, int parentId = 0,
            bool ignoreCategoriesWithoutExistingParent = false);
    }
}
