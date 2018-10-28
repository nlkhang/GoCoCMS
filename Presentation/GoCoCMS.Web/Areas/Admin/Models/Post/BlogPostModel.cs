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
        public string ContentOverview { get; set; }

        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int BlogCategoryId { get; set; }
        public IList<SelectListItem> AvailableCategories { get; set; }

        #endregion
    }
}
