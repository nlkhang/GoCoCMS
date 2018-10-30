using AutoMapper;
using GoCoCMS.Core.Mapper;
using GoCoCMS.Data.Domain;
using GoCoCMS.Web.Models.Category;
using GoCoCMS.Web.Models.Post;
using System.Collections.Generic;

namespace GoCoCMS.Web.Infrastructure.Mapper
{
    public class MapperConfig : Profile, IMapperProfile
    {
        #region Ctor

        public MapperConfig()
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

            // post
            CreateMap<List<PostModel>, List<BlogPost>>();
            CreateMap<List<BlogPost>, List<PostModel>>();
        }

        #endregion
    }
}
