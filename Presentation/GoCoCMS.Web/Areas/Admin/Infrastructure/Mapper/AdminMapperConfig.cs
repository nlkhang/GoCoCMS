using AutoMapper;
using GoCoCMS.Core.Mapper;
using GoCoCMS.Data.Domain;
using GoCoCMS.Web.Areas.Admin.Models;

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
            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();
        }

        #endregion
    }
}
