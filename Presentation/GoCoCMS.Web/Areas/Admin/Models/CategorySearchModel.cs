using System.ComponentModel.DataAnnotations;

namespace GoCoCMS.Web.Areas.Admin.Models
{
    public class CategorySearchModel
    {
        [Display(Name = "Category Name")]
        public string SearchCategoryName { get; set; }
    }
}
