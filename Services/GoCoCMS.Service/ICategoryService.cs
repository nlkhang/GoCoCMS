using GoCoCMS.Data.Domain;
using System.Collections.Generic;

namespace GoCoCMS.Service
{
    public interface ICategoryService
    {
        IList<Category> GetAllCategories(string categoryName);
        Category GetCategoryById(int categoryId);
        IList<Category> GetCategoriesByIds(int[] categoryIds);
        IList<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId);
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        string GetFormattedBreadCrumb(Category category, IList<Category> allCategories = null, string separator = ">>");
        IList<Category> GetCategoryBreadCrumb(Category category, IList<Category> allCategories = null);
        IList<Category> SortCategoriesForTree(IList<Category> source, int parentId = 0,
            bool ignoreCategoriesWithoutExistingParent = false);
    }
}
