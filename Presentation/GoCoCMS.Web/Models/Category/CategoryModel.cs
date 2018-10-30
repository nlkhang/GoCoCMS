using GoCoCMS.Web.Infrastructure.Model;
using System.Collections.Generic;

namespace GoCoCMS.Web.Models.Category
{
    public class CategoryModel : BaseEntityModel
    {
        public CategoryModel()
        {
            SubCategories = new List<CategoryModel>();
        }

        public string Name { get; set; }

        public List<CategoryModel> SubCategories { get; set; }
    }
}
