using GoCoCMS.Web.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoCoCMS.Web.Areas.Admin.Models.Post
{
    public class BlogPostModel : BaseEntityModel
    {
        #region Ctor

        public BlogPostModel()
        {
            this.AvailableCategories = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        public string Category { get; set; }

        public DateTime CreatedDate { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Category")]
        public int BlogCategoryId { get; set; }
        public IList<SelectListItem> AvailableCategories { get; set; }

        #endregion
    }
}
