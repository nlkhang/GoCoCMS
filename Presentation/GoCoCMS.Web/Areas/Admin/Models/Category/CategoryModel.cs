using GoCoCMS.Web.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoCoCMS.Web.Areas.Admin.Models.Category
{
    public class CategoryModel : BaseEntityModel
    {
        #region Ctor

        public CategoryModel()
        {
            this.AvailableCategories = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [Required]
        public string Name { get; set; }

        public string Breadcrumb { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Parent Category")]
        public int ParentCategoryId { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }

        #endregion
    }
}
