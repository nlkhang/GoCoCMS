using GoCoCMS.Data.Domain;
using GoCoCMS.Web.Areas.Admin.Models.Category;

namespace GoCoCMS.Web.Areas.Admin.Factories
{
    public interface IBlogCategoryModelFactory
    {
        CategoryListModel PrepareCategoryListModel(CategorySearchModel categorySearchModel);
        CategoryModel PrepareCategoryModel(CategoryModel categoryModel, BlogCategory category);
    }
}
