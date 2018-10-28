using AutoMapper;
using GoCoCMS.Core.Mapper;
using GoCoCMS.Data.Domain;
using GoCoCMS.Web.Areas.Admin.Models.Category;
using GoCoCMS.Web.Areas.Admin.Models.Post;

namespace GoCoCMS.Web.Areas.Admin.Infrastructure.Mapper
{
    public class AdminMapperConfig : Profile, IMapperProfile
    {
        #region Ctor

        public AdminMapperConfig()
        {
            CreateCategoryMaps();
        }

        #endregion

        #region Methods

        protected void CreateCategoryMaps()
        {
            // category
            CreateMap<CategoryModel, BlogCategory>();
            CreateMap<BlogCategory, CategoryModel>();

            // blog post
            CreateMap<BlogPostModel, BlogPost>()
                .ForMember(model => model.CreatedDate, option => option.Ignore());

            CreateMap<BlogPost, BlogPostModel>();
        }

        #endregion
    }
}
