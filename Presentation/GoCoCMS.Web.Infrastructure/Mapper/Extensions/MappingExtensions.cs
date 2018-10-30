using GoCoCMS.Core.Mapper;
using GoCoCMS.Data.Domain;
using GoCoCMS.Web.Infrastructure.Model;
using System;
using System.Collections.Generic;

namespace GoCoCMS.Web.Infrastructure.Mapper.Extensions
{
    public static class MappingExtensions
    {
        #region Methods

        public static TEntity ToEntity<TEntity>(this BaseEntityModel model) where TEntity : BaseEntity
        {
            return model.Map<TEntity>();
        }

        public static TEntity ToEntity<TEntity, TModel>(this TModel model, TEntity entity)
            where TEntity : BaseEntity where TModel : BaseEntityModel
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return model.MapTo(entity);
        }

        public static TModel ToModel<TModel>(this BaseEntity entity) where TModel : BaseEntityModel
        {
            return entity.Map<TModel>();
        }

        public static TModel ToModel<TModel, TEntity>(this IEnumerable<TEntity> entity) where TEntity : BaseEntity
        {
            return AutoMapperConfiguration.Mapper.Map<IEnumerable<TEntity>, TModel>(entity);
        }

        //public static TModel ToModel<TModel, TEntity>(this TEntity entity, TModel model)
        //    where TEntity : BaseEntity where TModel : BaseEntityModel
        //{
        //    if (model == null)
        //        throw new ArgumentNullException(nameof(model));

        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    return entity.MapTo(model);
        //}

        #endregion

        #region Utilities

        private static TDestination Map<TDestination>(this object source)
        {
            return AutoMapperConfiguration.Mapper.Map<TDestination>(source);
        }

        private static TDestination MapTo<TDestination, TSource>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #endregion
    }
}
