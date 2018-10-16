using GoCoCMS.Data.Domain;
using System.Collections.Generic;

namespace GoCoCMS.Service
{
    public interface ICategoryService
    {
        Category GetCategoryById(int categoryId);
        IList<Category> GetCategoryByIds(int[] categoryIds);
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        IList<Category> GetFormatedBreadCrumb(Category category, IList<Category> allCategories = null, string separator = ">");
        IList<Category> GetCategoryBreadCrumb(Category category, IList<Category> allCategories = null);
    }
}
