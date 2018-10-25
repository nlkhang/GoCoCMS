using GoCoCMS.Data.Domain;
using GoCoCMS.Web.Areas.Admin.Models;

namespace GoCoCMS.Web.Areas.Admin.Factories
{
    public interface ICategoryModelFactory
    {
        CategoryListModel PrepareCategoryListModel(CategorySearchModel categorySearchModel);
        CategoryModel PrepareCategoryModel(CategoryModel categoryModel, Category category);
    }
}
