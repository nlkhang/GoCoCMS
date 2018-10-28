﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoCoCMS.Data.Domain
{
    public class BlogPost : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ContentOverview { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int BlogCategoryId { get; set; }

        [ForeignKey(nameof(BlogCategoryId))]
        public virtual BlogCategory BlogCategory { get; set; }

        public bool Deleted { get; set; }
    }
}
