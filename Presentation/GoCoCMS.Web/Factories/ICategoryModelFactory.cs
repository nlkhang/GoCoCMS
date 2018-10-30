using GoCoCMS.Web.Models.Category;
using System.Collections.Generic;

namespace GoCoCMS.Web.Factories
{
    public interface ICategoryModelFactory
    {
        IList<CategoryModel> PrepareCategoryModel();
    }
}
