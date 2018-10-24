using System.Collections.Generic;

namespace GoCoCMS.Web.Areas.Admin.Models
{
    public class CategoryListModel
    {
        public CategoryListModel()
        {
            Categories = new List<CategoryModel>();
            CategorySearchModel = new CategorySearchModel();
        }

        public CategorySearchModel CategorySearchModel { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
